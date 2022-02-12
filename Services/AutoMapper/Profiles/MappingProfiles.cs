using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.PageUrls;
using Entities.PageUrls.PageUrlsDtos;
using Entities.Users;
using Entities.Users.UserDtos;

namespace Services.AutoMapper.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PageUrlsAddDtos, PageUrl>(); 
            CreateMap<PageUrlsUpdateDtos, PageUrl>();
            CreateMap<UserAddDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
