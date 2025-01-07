using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.DTOs.BlogDto
{
    public record CreateBlogDto(string Article,string Title,string Image,int AuthorId,int GenreId);
   
}
