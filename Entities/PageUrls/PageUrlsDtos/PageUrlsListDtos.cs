using Core.Model.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.PageUrls.PageUrlsDtos
{
    public class PageUrlsListDtos : DtoGetBase
    {
        public IList<PageUrl> PageUrls { get; set; }
    }
}
