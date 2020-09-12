using FluentValidation;
using SafraEducacional.Domain.Validator;
using SafraEducacional.Domain.Validator.Admin;

namespace SafraEducacional.Domain.DTO.User
{
    public class LoginDTO : BusinessValidator
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public override bool IsValid()
        {
            ValidationResult = new LoginValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}