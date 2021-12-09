using AutoMapper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.Entityframework.Dal.ProductDal;
using DataAccess.UnitOfWork;
using Entities;
using Entities.DTos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Services.ProductDataServices
{
    public class ProductDataService : IProductDataService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductDataService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

      

        public async Task<IResult> AddAsync(ProductAddDto productAddDto)
        {
            var product = _mapper.Map<Product>(productAddDto);
            await _unitOfWork.Products.AddAsync(product)
                .ContinueWith(t => _unitOfWork.SaveAsync());
            //await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, $"{productAddDto.Name} adlı ürün başarıyla eklenmiştir.");
        }





        public async Task<IResult> DeleteAsync(Guid productid)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == productid);
            if (product != null)
            {
                product.IsActive = false;
                await _unitOfWork.Products.DeleteAsync(product).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{product.Name} silindi.");
            }
            return new Result(ResultStatus.Error, "Kayıtlı Bir Ürün Bulunamadı");
        }

        public async Task<IDataResult<ProductDto>> GetAsync(Guid id) 
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == id);
            if (product != null)
            {
                return new DataResult<ProductDto>(ResultStatus.Success, new ProductDto {

                    Product = product,
                    ResultStatus = ResultStatus.Success
                });  ;
            }
            return new DataResult<ProductDto>(ResultStatus.Error, "Kayıtlı Bir Ürün Bulunamadı", null);
        }

        public async Task<IDataResult<ProductListDto>> GetListAsync()
        {
            var product = await _unitOfWork.Products.GetListAsync(p => p.IsActive == true);
            if (product.Count >= 0)
            {
                return new DataResult<ProductListDto>(ResultStatus.Success, new ProductListDto 
                {
                    Products = product,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<ProductListDto>(ResultStatus.Error, "Kayıtlı Bir Ürün Bulunamadı", null);
            
        }

        public async Task<IResult> UpdateAsync(ProductUpdateDto productUpdateDto)
        {
            var product = await _unitOfWork.Products.GetAsync(p => p.Id == productUpdateDto.Id);
            if (product != null)
            {
                product.Name = productUpdateDto.Name;
               
                await _unitOfWork.Products.UpdateAsync(product).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{productUpdateDto.Name} Ürünü Güncellendi."); 
            }
            return new Result(ResultStatus.Error, "Kayıtlı Bir Ürün Bulunamadı");
        }
    }
}
