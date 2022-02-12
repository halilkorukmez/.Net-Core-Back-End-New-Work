using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Model;
using Entities.PageUrls;

namespace Entities.Users
{
    public class User : BaseModel
    {
        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(12)]
        [MinLength(6)]
        public string Password { get; set; }
        public IList<PageUrl>? PageUrls { get; set; }
    }
}