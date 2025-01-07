using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Persistence.Configurations
{
    internal class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.SizeId });
        }
    }
}
