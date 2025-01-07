using FluentValidation;
using ProniaOnion.Application.DTOs.GenreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.FluentValidator.GenreDtoValidator
{
    public class CreateGenreDtoValidator:AbstractValidator<CreateGenreDto>
    {
        public CreateGenreDtoValidator()
        {
            RuleFor(a => a.Name).NotEmpty()
                
                .WithMessage("Name Required")
                .MaximumLength(100)
                    .WithMessage("Must contains max 100 symbols")
                 .Matches(@"^[A-Za-z]*$");
        }
    }
}
