using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.DataContext;
using DataAccess.UnitOfWork;
using Entities.PageUrls;
using Entities.PageUrls.PageUrlsDtos;
using Microsoft.EntityFrameworkCore;


namespace Services.PageUrlsDataServices
{
    public class PageUrlsDataService : IPageUrlsDataService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly WorkerDataContext _context;

        public PageUrlsDataService(IUnitOfWork unitOfWork, IMapper mapper, WorkerDataContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }



        public async Task<IResult> AddAsync(PageUrlsAddDtos pageUrlsAddDtos)
        {
            var pageUrl = _mapper.Map<PageUrl>(pageUrlsAddDtos); 
            if (_context.PageUrls.Any(x => x.UrlAddress == pageUrlsAddDtos.UrlAddress))
            {return new Result(ResultStatus.Error, $"{pageUrl.UrlAddress}  Daha Önceden Alınmış");
               
                
            }
            else
            
                await _unitOfWork.PageUrl.AddAsync(pageUrl)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{pageUrl.UrlName} Adlı URL Başarıyla Eklenmiştir.");
            
            
        }

        public async Task<IResult> DeleteAsync(Guid productId)
        {
            var pageUrl = await _unitOfWork.PageUrl.GetAsync(p => p.Id == productId);
            if (pageUrl != null)
            {
                pageUrl.IsActive = false;
                await _unitOfWork.PageUrl.DeleteAsync(pageUrl).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{pageUrl.UrlName} Silindi.");
            }
            return new Result(ResultStatus.Error, "Kayıtlı Bir URL Bulunamadı");
        }

        public async Task<IDataResult<PageUrlsDtos>> GetAsync(Guid id) 
        {
            var pageUrl = await _unitOfWork.PageUrl.GetAsync(p => p.Id == id);
            if (pageUrl != null)
            {
                return new DataResult<PageUrlsDtos>(ResultStatus.Success, new PageUrlsDtos {

                    PageUrl = pageUrl,
                    ResultStatus = ResultStatus.Success
                }); 
            }
            return new DataResult<PageUrlsDtos>(ResultStatus.Error, "Kayıtlı Bir URL Bulunamadı", null);
        }

        public async Task<IDataResult<PageUrlsListDtos>> GetUserIdAsync(Guid id)
        { 
        
           
            var pageUrls = await _unitOfWork.PageUrl.GetListAsync(p => p.UserId == id);
            if (pageUrls.Count >= 0)
            {
                return new DataResult<PageUrlsListDtos>(ResultStatus.Success, new PageUrlsListDtos 
                {
                    PageUrls = pageUrls,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<PageUrlsListDtos>(ResultStatus.Error, "Kayıtlı Bir URL Bulunamadı", null);
        }

        public async Task<IDataResult<PageUrlsListDtos>> GetListAsync()
        {
            var pageUrls = await _unitOfWork.PageUrl.GetListAsync(p => p.IsActive == true);
            if (pageUrls.Count >= 0)
            {
                return new DataResult<PageUrlsListDtos>(ResultStatus.Success, new PageUrlsListDtos 
                {
                    PageUrls = pageUrls,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<PageUrlsListDtos>(ResultStatus.Error, "Kayıtlı Bir URL Bulunamadı", null);
            
        }

        public async Task<IResult> UpdateAsync(PageUrlsUpdateDtos pageUrlsUpdateDtos)
        {
            var pageUrls = await _unitOfWork.PageUrl.GetAsync(p => p.Id == pageUrlsUpdateDtos.Id);
            if (pageUrls != null)
            {
                pageUrls.UrlName = pageUrlsUpdateDtos.UrlName;
               
                await _unitOfWork.PageUrl.UpdateAsync(pageUrls).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{pageUrlsUpdateDtos.UrlName} Ürünü Güncellendi."); 
            }
            return new Result(ResultStatus.Error, "Kayıtlı Bir URL Bulunamadı");
        }
    }
}
