using Core.ServicesModel;
using Core.Utilities.Result.Abstract;
using Entities;
using Entities.DTos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.ProductDataServices
{
    public interface IProductDataService 
    {
        Task<IDataResult<ProductDto>> GetAsync(Guid id);
        Task<IDataResult<ProductListDto>> GetListAsync();
        Task<IResult> AddAsync(ProductAddDto productAddDto);
        Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto);
        Task<IResult> DeleteAsync(Guid productid);


    }   
}
