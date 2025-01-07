using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repostories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.Implementations.Repostories
{
    internal class ProductRepository:Repository<Product>,IProductRepository
    {
        public ProductRepository(AppDbContext context):base(context) { }
    }
}
