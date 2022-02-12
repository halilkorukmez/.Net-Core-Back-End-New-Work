using System;
using System.ComponentModel.DataAnnotations;
using Core.Model.DtoModel;

namespace Entities.Users.UserDtos
{
    public class UserAddDto : DtoGetBase
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(15)]
        public string Password { get; set; }
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool IsActive { get; set; }
        
    }
}