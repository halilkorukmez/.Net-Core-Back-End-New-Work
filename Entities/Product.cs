using Core.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Product : BaseModel,IEntity
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
    }
}
