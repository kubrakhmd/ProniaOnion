using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productrepo, IMapper mapper)
        {
            _productRepository = productrepo;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductItemDto>> GetAll(int page, int take)
        {
            List<Product> products = await _productRepository
                    .GetAll(skip: (page - 1) * take, take: take)
                    .ToListAsync();
            return _mapper.Map<IEnumerable<ProductItemDto>>(products);
        }
        public async Task<GetProductDto> GetByIdAsync(int id)
        {
            Product product = await _productRepository.GetByIdAsync(id, "Category",
                "ProductColors.Color",
                "ProductSizes.Size",
                "ProductTags.Tag");
            if (product is null) throw new Exception("Not Found");
            return _mapper.Map<GetProductDto>(product);
        }

    }
}
