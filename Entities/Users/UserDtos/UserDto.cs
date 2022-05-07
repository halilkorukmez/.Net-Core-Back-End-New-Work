using System;

namespace Entities.Users.UserDtos
{
    public class UserDto 
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        
    }
}