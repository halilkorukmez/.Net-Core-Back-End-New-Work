using AutoMapper;
using Entities;
using Entities.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AutoMapper.Profiles
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            CreateMap<ProductAddDto, Product>(); //.ForMember(dest => dest.DateTime,opt => opt.MapFrom(x =>DateTime.Now));
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
