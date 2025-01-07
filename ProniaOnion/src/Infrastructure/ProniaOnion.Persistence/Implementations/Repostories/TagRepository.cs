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
    internal class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context) { }
    }
}
