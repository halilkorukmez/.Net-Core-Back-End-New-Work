using System.Collections;
using System.Collections.Generic;
using Core.Model.DtoModel;

namespace Entities.Users.UserDtos
{
    public class UserListDto : DtoGetBase
    {
        public IList<User> Users { get; set; }
    }
}