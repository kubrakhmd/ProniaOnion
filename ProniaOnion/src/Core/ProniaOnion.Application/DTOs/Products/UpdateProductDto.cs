﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.Products
{
    public record UpdateProductDto(
        decimal Price,
        string Name,
        string SKU,
        string Description,
        int CategoryId,
        ICollection<int> TagIds,
        ICollection<int> ColorIds,
        ICollection<int> SizeIds
        );
}
