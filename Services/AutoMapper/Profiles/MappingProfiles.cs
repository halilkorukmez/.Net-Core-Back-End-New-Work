using AutoMapper;
using Entities.Users;
using Services.MediatR.Users.Commands.Create;
using Services.MediatR.Users.Commands.Update;

namespace Services.AutoMapper.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCommad, User>();
            CreateMap<UpdateCommand, User>();
            
        }
    }
}
