using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork;
using Entities.Users;
using Entities.Users.UserDtos;

namespace Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public LoginService(IUnitOfWork unitOfWork, IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }


        public async Task<IDataResult<UserDto>> LoginAsync(string userName, string password)
        {
            var user = await _unitOfWork.Users.GetAsync(p => p.UserName == userName && p.Password == password);
            if (user != null)
            {
                return new DataResult<UserDto>(ResultStatus.Success, new UserDto
                {
                    User = user,
                    ResultStatus = ResultStatus.Success
                }); ;
            }
            return new DataResult<UserDto>(ResultStatus.Error, "Kayıtlı Bir Kullanıcı Bulunamadı", null);
        }
    }
}