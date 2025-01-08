using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.DTOs.Products;

namespace ProniaOnion.Application.Abstractions.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductItemDto>> GetAll(int page, int take);
        Task<GetProductDto> GetByIdAsync(int id);
      
    }
}
