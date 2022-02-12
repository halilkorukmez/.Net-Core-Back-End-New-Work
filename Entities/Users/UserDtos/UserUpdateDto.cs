using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Core.Model.DtoModel;

namespace Entities.Users.UserDtos
{
    public class UserUpdateDto : DtoGetBase
    {
        [Required]
        public Guid Id { get; set; }
        
        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        [MaxLength(30, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz")]
        [MinLength(5, ErrorMessage = "{0} {1} Karakterden Az Olamaz")]
        public string UserName { get; set; }
        
        [DisplayName("Kullanıcı Şifresi")]
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        [MaxLength(12, ErrorMessage = "{0} {1} Karakterden Büyük Olamaz")]
        [MinLength(6, ErrorMessage = "{0} {1} Karakterden Az Olamaz")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "{0} Girilmesi Zorunludur")]
        public bool IsActive { get; set; }

        public DateTime? UpdateDate { get; set; }
        
    }
}