﻿using FluentValidation;
using ProniaOnion.Application.DTOs.AuthorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.FluentValidator.AuthorDtoValidator
{
   public class CreateAuthorDtoValidator:AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorDtoValidator()
        {
            RuleFor(a=>a.Name).NotEmpty().WithMessage("Name Required")
                .MaximumLength(25).WithMessage("Name must contains max 25 symbols")
                .Matches(@"^[A-Za-z]*$");
            RuleFor(a => a.Surname).NotEmpty().WithMessage("Surname Required")
               .MaximumLength(30).WithMessage("Surname must contains max 30 symbols")
               .Matches(@"^[A-Za-z]*$");
        }
    }
}
