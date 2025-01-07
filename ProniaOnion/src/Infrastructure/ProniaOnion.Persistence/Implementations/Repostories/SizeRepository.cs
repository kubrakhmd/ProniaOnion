using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Domain.Entities;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repostories.Generic;

namespace ProniaOnion.Persistence.Implementations.Repostories
{
    internal class SizeRepository : Repository<Size>, ISizeRepository
    {
        public SizeRepository(AppDbContext context) : base(context) { }
    }
}