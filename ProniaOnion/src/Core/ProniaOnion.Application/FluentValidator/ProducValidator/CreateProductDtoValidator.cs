﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.FluentValidator.ProducValidator
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    { 
        public const int NAME_MAX_LENGTH=100;
        public const int SKU_MAX_LENGTH = 10;
        public const int SKU_MIN_LENGTH = 4;
        public const decimal PRICE_MAX =9999.99m;
        public const decimal PRICE_MIN = 3;
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                .WithMessage("Name Required")
            .MaximumLength(NAME_MAX_LENGTH)
                .WithMessage("Name must contains max 100 symbols");

            RuleFor(p => p.SKU).NotEmpty()
                .WithMessage("SKU Code Required")
            .MinimumLength(SKU_MIN_LENGTH).MaximumLength(SKU_MAX_LENGTH)
                   .WithMessage("SKU Code must contains min 4,max 10 symbols");

            RuleFor(p => p.Price).NotEmpty()
                    .WithMessage("Price Required")
                .GreaterThanOrEqualTo(PRICE_MIN).LessThanOrEqualTo(PRICE_MAX);

            RuleFor(p => p.Description)
                .NotEmpty()
                    .WithMessage("Description Required");

            RuleFor(p => p.CategoryId)
                .NotEmpty()
                    .Must(id => id > 0);
            RuleForEach(p => p.TagIds)
               .NotEmpty()
               .Must(id => id > 0);

            RuleForEach(p => p.ColorIds)
                .NotEmpty()
                .Must(id => id > 0);

            RuleForEach(p => p.SizeIds)
                .NotEmpty()
                .Must(id => id > 0);

            RuleFor(p => p.TagIds)
                .Must(c => c.Count > 0);

            RuleFor(p => p.SizeIds)
                .Must(c => c.Count > 0);
            RuleFor(p => p.ColorIds)
              .Must(c => c.Count > 0);
        }
    }

}
