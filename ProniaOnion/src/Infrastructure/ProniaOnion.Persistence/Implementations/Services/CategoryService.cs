﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application;
using ProniaOnion.Application.DTOs.Products;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Persistence.Implementations.Repostories.Generic;

namespace ProniaOnion.Persistence.Implementations.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CreateCategoryDto categoryDto)
        {
            if (await _categoryRepository.AnyAsync(c => c.Name == categoryDto.Name)) throw new Exception("Already exists") ;

           var category=_mapper.Map<Category>(categoryDto);

            category.CreatedAt=DateTime.Now;
            category.ModifiedAt=DateTime.Now;

            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
             
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not found");
            _categoryRepository.Delete(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Category> categories = await _categoryRepository
                 .GetAll(skip: (page - 1) * take, take: take)
                 .ToListAsync();
               
            return _mapper.Map<IEnumerable<CategoryItemDto>>(categories);
        }

        public async Task<GetCategoryDto> GetByIdAsync(int id)
        {

            Category category = await _categoryRepository.GetByIdAsync(id, nameof(Category.Products));


            if (category == null) return null;

         
          
            GetCategoryDto categoryDto=_mapper.Map<GetCategoryDto>(category);

            return categoryDto;
        }




        public async Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not found");
            if (await _categoryRepository.AnyAsync(c => c.Name == categoryDto.Name && c.Id != id)) throw new Exception("Already exists");
           
            category=_mapper.Map<Category>(categoryDto);
            category.Id = id;

            category.Name = categoryDto.Name;
            category.ModifiedAt=DateTime.Now;

            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task SoftDelete(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new Exception("Not found");
            category.IsDeleted = true;
            _categoryRepository.Update(category);
            await _categoryRepository.SaveChangesAsync();
        }

    }
}
