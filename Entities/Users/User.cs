using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Model;

namespace Entities.Users
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
      
    }
}