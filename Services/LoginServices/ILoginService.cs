using System.Threading.Tasks;
using Core.Utilities.Result.Abstract;
using Entities.Users;
using Entities.Users.UserDtos;

namespace Services.LoginServices
{
    public interface ILoginService
    {
        Task<IDataResult<UserDto>>  LoginAsync(string name, string password);
    }
}