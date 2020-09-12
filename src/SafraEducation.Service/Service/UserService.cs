using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SafraEducacional.Domain.DTO.Login;
using SafraEducacional.Domain.DTO.User;
using SafraEducacional.Domain.Interface.Service;
using SafraEducacional.Domain.Notification;
using SafraEducacional.Domain.Security;
using SafraEducation.Domain.Interface.Repository;

namespace SafraEducacional.Services
{
    public class UserService : IUserService
    {
        private readonly NotificationContext _notificationContext;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasherService _passwordService;

        public UserService(NotificationContext notificationContext,
                            IConfiguration configuration,
                            IMapper mapper,
                            IPasswordHasherService passwordService,
                            IUserRepository userRepository)
        {
            _mapper = mapper;
            _notificationContext = notificationContext;
            _configuration = configuration;
            _userRepository = userRepository;
            _notificationContext = notificationContext;
            _passwordService = passwordService;
        }

        public bool Authenticate(string passwordStored, string passwordInputed)
        {
            return _passwordService.Check(passwordStored, passwordInputed).Verified;           
        }

        public async Task<LoginAccessDTO> Login(LoginDTO credentials)
        {
            if (!credentials.IsValid())
            {
                _notificationContext.AddNotifications(credentials.ValidationResult);
                return null;
            }
            else
            {
                var user = await _userRepository.GetByLogin(credentials.Login);               

                if (user != null && Authenticate(user.PasswordDigest, credentials.Password))
                {
                    return TokenObject(_mapper.Map<UserDTO>(user));
                }
                else
                {
                    return new LoginAccessDTO
                    {
                        Authenticated = false,
                        AccessToken = null
                    };
                }
            }
        }

        private LoginAccessDTO TokenObject(UserDTO user)
        {
            var appSettingsSection = _configuration.GetSection("AppSettings");
            var tokenSettings = appSettingsSection.Get<TokenConfiguration>();
            var key = Encoding.ASCII.GetBytes(tokenSettings.Key);
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Name),
                new[]
                {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Actort, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
                }
            );

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate + TimeSpan.FromMinutes(tokenSettings.Minuts);

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenSettings.Issuer,
                Audience = tokenSettings.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = identity,
                NotBefore = createDate,
                IssuedAt = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(securityToken);

            return new LoginAccessDTO
            {
                Authenticated = true,
                AccessToken = token
            };
        }
    }
}