using Core.Model.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTos
{
    public class ProductListDto : DtoGetBase
    {
        public IList<Product> Products { get; set; }
    }
}
