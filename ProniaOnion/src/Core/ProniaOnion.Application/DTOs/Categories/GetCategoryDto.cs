using ProniaOnion.Application.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application
{ 
    public record GetCategoryDto(int Id,string Name,ICollection<ProductItemDto>Products);
}
