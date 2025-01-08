﻿using AutoMapper;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductItemDto>();
            CreateMap<Product, GetProductDto>()
                .ForCtorParam(nameof(GetProductDto.Colors),
                opt => opt.MapFrom(
                    p => p.ProductColors.Select(pc => new ColorItemDto(pc.ColorId, pc.Color.Name)).ToList())
                ).ForCtorParam(nameof(GetProductDto.Sizes),
               opt => opt.MapFrom(
                   p => p.ProductSizes.Select(pc => new SizeItemDto(pc.SizeId, pc.Size.Name)).ToList())
               )
                .ForCtorParam(nameof(GetProductDto.Tags),
               opt => opt.MapFrom(
                   p => p.ProductTags.Select(pc => new TagItemDto(pc.TagId, pc.Tag.Name)).ToList())
               )
               ;


        }
    }
}
