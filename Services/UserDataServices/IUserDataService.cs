using System;
using System.Threading.Tasks;
using Core.Utilities.Result.Abstract;
using Entities.Users.UserDtos;


namespace Services.UserDataServices
{
    public interface IUserDataService
    {
        Task<IDataResult<UserDto>> GetAsync(Guid id);
        Task<IDataResult<UserListDto>> GetListAsync();
        Task<IResult> AddAsync(UserAddDto userAddDto);
        Task<IResult> UpdateAsync(UserUpdateDto userUpdateDto);
     
        
        

    }
}