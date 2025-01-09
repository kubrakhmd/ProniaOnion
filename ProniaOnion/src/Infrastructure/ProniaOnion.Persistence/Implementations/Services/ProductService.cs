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
using ProniaOnion.Persistence.Implementations.Repostories;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productrepo, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productrepo;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
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
        public async Task CreateAsync(CreateProductDto productDto)
        {
            if (!await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId))
                throw new Exception("Category does not exists");
            var colorEntities = await _productRepository.GetManyToManyEntities<Color>(productDto.ColorIds);
            if (colorEntities.Count() != productDto.ColorIds.Distinct().Count())
                throw new Exception("Color id is wrong");
            var tagEntities = await _productRepository.GetManyToManyEntities<Tag>(productDto.TagIds);
            if (tagEntities.Count() != productDto.TagIds.Distinct().Count())
                throw new Exception("Tag id is wrong");
            var sizeEntities = await _productRepository.GetManyToManyEntities<Size>(productDto.SizeIds);
            if (sizeEntities.Count() != productDto.SizeIds.Distinct().Count())
                throw new Exception("Size id is wrong");
            await _productRepository.AddAsync(_mapper.Map<Product>(productDto));
            await _productRepository.SaveChangesAsync();
        }
        public async Task UpdateAsync(int id, UpdateProductDto productDto)
        {
            Product product = await _productRepository.GetByIdAsync(id, "ProductColors", "ProductTags", "ProductSizes");
            if (productDto.CategoryId != product.CategoryId)
                if (!await _categoryRepository.AnyAsync(c => c.Id == productDto.CategoryId))
                    throw new Exception("Category does not exists");

            // product.ProductColors=product.ProductColors.Where(pc=>productDto.ColorIds.Contains(pc.ColorId)).ToList();

            ICollection<int> createItems = productDto.ColorIds
                .Where(cId => !product.ProductColors.Any(pc => pc.ColorId == cId)).ToList();
            var colorEntities = await _productRepository.GetManyToManyEntities<Color>(createItems);
            if (colorEntities.Count() != createItems.Distinct().Count())
                throw new Exception("One or more color id is wrong");
            


            ICollection<int> createItems2 = productDto.SizeIds
                .Where(cId => !product.ProductSizes.Any(ps => ps.SizeId == cId)).ToList();
            var sizeEntities = await _productRepository.GetManyToManyEntities<Size>(createItems2);
            if (sizeEntities.Count() != createItems2.Distinct().Count())
                throw new Exception("One or more size id is wrong");


            ICollection<int> createItems3 = productDto.TagIds
                .Where(cId => !product.ProductTags.Any(pt => pt.TagId == cId)).ToList();
            var tagEntities = await _productRepository.GetManyToManyEntities<Tag>(createItems3);
            if (tagEntities.Count() != createItems3.Distinct().Count())
                throw new Exception("One or more tag id is wrong");

            _productRepository.Update(_mapper.Map(productDto, product));
            await _productRepository.SaveChangesAsync();

        }

    }
}
