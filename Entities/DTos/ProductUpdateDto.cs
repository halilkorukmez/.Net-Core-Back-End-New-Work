using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTos
{
    public class ProductUpdateDto
    {
        [Required]
        public Guid Id { get; set; }


        [DisplayName("Ürün Adı")]
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz")]
        [MinLength(3, ErrorMessage = "{0} {1} Karakterden Az Olamaz")]
        public string Name { get; set; }


        [DisplayName("Aktif Mi ?")]
        [Required(ErrorMessage = "{0} Boş Geçilemez")]
        public bool IsActive { get; set; }

    }
}
