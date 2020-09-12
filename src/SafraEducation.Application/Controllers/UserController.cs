using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SafraEducacional.Domain.DTO.User;
using SafraEducacional.Domain.Interface.Service;

namespace SafraEducation.Application.Controllers
{
    [ApiController]
    [Route("safra-education-api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) : base()
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                var result = await _userService.Login(login);
                return result is null || !result.Authenticated ? (IActionResult)NotFound() : Created(result.AccessToken, result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}