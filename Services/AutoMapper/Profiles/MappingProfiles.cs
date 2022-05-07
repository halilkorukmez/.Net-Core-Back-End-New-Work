using AutoMapper;
using Entities.Users;
using Entities.Users.UserDtos;
using Services.MediatR.Users.Commands.Create;
using Services.MediatR.Users.Commands.Update;
using Services.MediatR.Users.Queries.GetList;

namespace Services.AutoMapper.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCommad, User>();
            CreateMap<UpdateCommand, User>();
            CreateMap<UserListDto, User>();
        }
    }
}
