using ProniaOnion.Application.DTOs;
using ProniaOnion.Application.DTOs.GenreDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
   public interface IGenreService
    {
        Task<IEnumerable<GenreItemDto>> GetAllAsync(int page, int take);

        Task<GetGenreDto> GetByIdAsync(int id);

        Task CreateAsync(CreateGenreDto genreDto);

        Task UpdateAsync(int id, UpdateGenreDto genroDto);

        Task DeleteAsync(int id);
    }
}
