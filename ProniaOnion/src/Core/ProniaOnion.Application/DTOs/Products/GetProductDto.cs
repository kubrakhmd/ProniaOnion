using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.Products
{
    public record GetProductDto(int Id, string Name, decimal Price, CategoryItemDto Category,
      string SKU, string Decription,
          IEnumerable<TagItemDto> Tags,
   IEnumerable<SizeItemDto> Sizes,
   IEnumerable<ColorItemDto> Colors
 );
}
