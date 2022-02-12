using Core.Model.DtoModel;

namespace Entities.Users.UserDtos
{
    public class UserDto : DtoGetBase
    {
        public User User { get; set; }
        
    }
}