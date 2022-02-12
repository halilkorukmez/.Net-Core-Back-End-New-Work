using Core.Utilities.Result.Abstract;
using System;
using System.Threading.Tasks;
using Entities.PageUrls.PageUrlsDtos;

namespace Services.PageUrlsDataServices
{
    public interface IPageUrlsDataService 
    {
        Task<IDataResult<PageUrlsDtos>> GetAsync(Guid id);
        Task<IDataResult<PageUrlsListDtos>> GetUserIdAsync(Guid userId);
        Task<IDataResult<PageUrlsListDtos>> GetListAsync();
        Task<IResult> AddAsync(PageUrlsAddDtos pageUrlsAddDtos);
        Task<IResult> UpdateAsync(PageUrlsUpdateDtos ageUrlsUpdateDtos);
        Task<IResult> DeleteAsync(Guid pageUrlId);


    }   
}
