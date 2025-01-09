using AutoMapper;
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
                   p => p.ProductSizes.Select(ps => new SizeItemDto(ps.SizeId, ps.Size.Name)).ToList())
               )
                .ForCtorParam(nameof(GetProductDto.Tags),
               opt => opt.MapFrom(
                   p => p.ProductTags.Select(pt => new TagItemDto(pt.TagId, pt.Tag.Name)).ToList())
               );
            CreateMap<CreateProductDto, Product>()
               .ForMember(p => p.ProductColors,
               opt => opt.MapFrom(pDto => pDto.ColorIds.Select(ci => new ProductColor { ColorId = ci }))
               )
               .ForMember(p => p.ProductSizes,
               opt => opt.MapFrom(pDto => pDto.SizeIds.Select(si => new ProductSize { SizeId = si }))
               )
               .ForMember(p => p.ProductTags,
               opt => opt.MapFrom(pDto => pDto.TagIds.Select(ti => new ProductTag { TagId = ti }))
               );
               
            CreateMap<UpdateProductDto, Product>()
               .ForMember(
                p => p.Id,
                opt => opt.Ignore())
                .ForMember(
                p => p.ProductColors,
                opt => opt.MapFrom(pDto => pDto.ColorIds.Select(ci => new ProductColor { ColorId = ci }))

                )
                .ForMember(
                p => p.ProductSizes,
                opt => opt.MapFrom(pDto => pDto.SizeIds.Select(ci => new ProductSize { SizeId = ci }))
                )
                 .ForMember(
                p => p.ProductTags,
                opt => opt.MapFrom(pDto => pDto.TagIds.Select(ci => new ProductTag { TagId = ci }))
                )
                 ;
        }
    }
}
