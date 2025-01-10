
using FluentValidation;
using ProniaOnion.Application.DTOs.AppUsers;

namespace ProniaOnion.Application.FluentValidator.UserValidator
{
    internal class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Name)
              .NotEmpty()
              .MinimumLength(3)
              .MaximumLength(50)
                .WithMessage("Name must contains max 50 symbols")
              .Matches(@"^[A-Za-z]*$");

            RuleFor(r => r.Surname)
               .NotEmpty()
               .MinimumLength(3)
               .MaximumLength(50)
                .WithMessage("Surname must contains max 50 symbols")
               .Matches(@"^[A-Za-z]*$");


            RuleFor(r => r.UserName)
               .NotEmpty()
               .MinimumLength(4)
               .MaximumLength(256)
               . WithMessage("username must contains max 256 symbols")
               .Matches(@"^[A-Za-z0-9-._@+]*$");

            RuleFor(r => r.Email)
               .NotEmpty()
               .MinimumLength(6)
               .MaximumLength(256)
                .WithMessage("Email must contains max 256 symbols")
               .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            RuleFor(r => r.Password)
               .NotEmpty()
               .MinimumLength(8)
               .MaximumLength(100)
                .WithMessage("Password must contains max 100 symbols");
            
        }
    }
}
