using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface ISizeService
    {
        Task<IEnumerable<SizeItemDto>> GetAllAsync(int page, int take);
        Task<GetSizeDto> GetByIdAsync(int id);
        Task CreateAsync(CreateSizeDto sizeDto);
        Task UpdateAsync(int id, UpdateSizeDto sizeDto);
        Task DeleteAsync(int id);
    }
}
