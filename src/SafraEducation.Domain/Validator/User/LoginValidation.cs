using FluentValidation;
using SafraEducacional.Domain.DTO.User;

namespace SafraEducacional.Domain.Validator.Admin
{
    public class LoginValidation : AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(r => r.Login)
                .NotEmpty()
                    .WithMessage("O login é obrigatório");

            RuleFor(r => r.Password)
                .NotEmpty()
                    .WithMessage("A senha é obrigatória");
        }
    }
}