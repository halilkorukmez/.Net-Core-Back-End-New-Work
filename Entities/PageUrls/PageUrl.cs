using Core.Model;
using System;
using System.ComponentModel.DataAnnotations;
using Entities.Users;

namespace Entities.PageUrls
{
    public class PageUrl : BaseModel
    {
        [Required]
        [MaxLength(30)]
        public string UrlName { get; set; }
        
        [Required]
        public string UrlAddress { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
        
    }
}
