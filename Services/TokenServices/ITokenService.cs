using Core.Utilities.Result.Abstract;
using Entities.Users;
using Entities.Users.UserDtos;

namespace Services.TokenServices
{
    public interface ITokenService
    {
        string GetToken(IDataResult<UserDto> user);
       
    }
}