using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.BlogDto
{
   public record UpdateBlogDto (string Article, string Title,  string Image, int GenreId, int AuthorId);
   
}
