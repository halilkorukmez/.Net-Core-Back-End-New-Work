using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Users;

namespace Entities.PageUrls.PageUrlsDtos
{
    public class PageUrlsAddDtos
    {
        [Required]
        [MaxLength(30)]
        [MinLength(5)]
        public string UrlName { get; set; }
        [Required]
        [MinLength(5)]
        public string UrlAddress { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public Guid UserId { get; set; }
        

    }
}
