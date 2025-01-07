using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.AuthorDto;
using ProniaOnion.Application.DTOs.BlogDto;
using ProniaOnion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Services
{
    public class BlogService:IBlogService
    {
        private readonly IBlogRepository _repository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BlogItemDto>> GetAllAsync(int page, int take)
        {
            IEnumerable<Blog> blogs = await _repository
                .GetAll(skip: (page - 1) * take, take: take)
                 .ToListAsync();

            return _mapper.Map<IEnumerable<BlogItemDto>>(blogs);
        }

        public async Task<GetBlogDto> GetbyIdAsync(int id)
        {
            Blog blog = await _repository.GetByIdAsync(id,nameof(Blog.Author),nameof(Blog.Genre));
            if (blog == null) throw new Exception("Not Found");


            return _mapper.Map<GetBlogDto>(blog);
        }

        public async Task CreateAsync(CreateBlogDto blogDto)
        {

            var author = _mapper.Map<Blog>(blogDto);

            author.CreatedAt = DateTime.Now;
            author.ModifiedAt = DateTime.Now;
            await _repository.AddAsync(author);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, UpdateBlogDto blogDto)
        {
            Blog blog = await _repository.GetByIdAsync(id);
            if (blog == null) throw new Exception("Not found");
            if (await _repository.AnyAsync(c => c.Id != id)) throw new Exception("Already exists");

            blog = _mapper.Map(blogDto, blog);
            blog.Article = blogDto.Article;
            blog.Image = blogDto.Image;
            blog.AuthorId = blogDto.AuthorId;
            blog.GenreId = blogDto.GenreId;


            _repository.Update(blog);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            Blog blog = await _repository.GetByIdAsync(Id);
            if (blog == null) throw new Exception("Not Found");

            _repository.Delete(blog);

            await _repository.SaveChangesAsync();
        }
        public async Task SoftDelete(int id)
        {
            Blog blog = await _repository.GetByIdAsync(id);
            if (blog == null) throw new Exception("Not found");
            blog.IsDeleted = true;
            _repository.Update(blog);
            await _repository.SaveChangesAsync();
        }
    }
}
