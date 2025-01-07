using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.AuthorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorItemDto>> GetAllAsync(int page, int take);

        Task<GetAuthorDto> GetByIdAsync(int id);

        Task CreateAsync(CreateAuthorDto authorDto);

        Task UpdateAsync(int id,UpdateAuthorDto authorDto);

        Task DeleteAsync(int id);
    }
}
