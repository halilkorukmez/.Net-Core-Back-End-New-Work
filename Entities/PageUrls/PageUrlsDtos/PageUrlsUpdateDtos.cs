using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageUrls.PageUrlsDtos
{
    public class PageUrlsUpdateDtos
    {
        [Required]
        public Guid Id { get; set; }


        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olamaz")]
        public string UrlName { get; set; }
        
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        public string UrlAddress { get; set; }

     

    }
}
