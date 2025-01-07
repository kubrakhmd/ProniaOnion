using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ProniaOnion.Domain.Entities;

namespace ProniaOnion.Application.MappingProfiles
{
    internal class TagProfile :Profile
    {
        public TagProfile()
        {

            CreateMap<Tag, GetTagDto>().ReverseMap();
            CreateMap<Tag, TagItemDto>();
            CreateMap<CreateTagDto, Tag>();
            CreateMap<UpdateTagDto, Tag>();
        }
    }
}
