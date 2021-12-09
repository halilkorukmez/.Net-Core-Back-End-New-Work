using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTos
{
    public class ProductAddDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public Guid Id { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}
