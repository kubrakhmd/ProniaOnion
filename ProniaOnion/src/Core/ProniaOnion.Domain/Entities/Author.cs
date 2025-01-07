using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public class Author:BaseNameableEntity
    {
        public string Surname { get; set; }
        public string ProfilePhoto {  get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
