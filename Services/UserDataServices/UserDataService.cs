using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.DataContext;
using DataAccess.UnitOfWork;
using Entities.Users;
using Entities.Users.UserDtos;

namespace Services.UserDataServices
{
    public class UserDataService : IUserDataService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly WorkerDataContext _context;

        public UserDataService(IUnitOfWork unitOfWork, IMapper mapper, WorkerDataContext dataContext)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = dataContext;
        }
        
        public async Task<IDataResult<UserDto>> GetAsync(Guid id)
        {
            var user = await _unitOfWork.Users.GetAsync(p => p.Id == id);
            if (user != null)
            {
                return new DataResult<UserDto>(ResultStatus.Success, new UserDto() {

                    User = user,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<UserDto>(ResultStatus.Error, "Kayıtlı Bir Kullanıcı Bulunamadı", null);
        }

        public async Task<IDataResult<UserListDto>> GetListAsync()
        {
            var users = await _unitOfWork.Users.GetListAsync(p => p.IsActive == true);
            if (users.Count >= 0)
            {
                return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto 
                {
                    Users = users,
                    ResultStatus = ResultStatus.Success
                });

            }
            return new DataResult<UserListDto>(ResultStatus.Error, "Kayıtlı Bir Kullanıcı Bulunamadı", null);

        }

        public async Task<IResult> AddAsync(UserAddDto userAddDto)
        {
            var user = _mapper.Map<User>(userAddDto);
            if (_context.Users.Any(x => x.UserName != userAddDto.UserName))
                return new Result(ResultStatus.Error, $"{user.UserName} Kullanıcı Adı Daha Önceden Alınmış");
           
            else
                await _unitOfWork.Users.AddAsync(user)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
            return new Result(ResultStatus.Success, $"{user.Name} Adlı Kullanıcı Başarıyla Eklenmiştir.");
        }

        public async Task<IResult> UpdateAsync(UserUpdateDto userUpdateDto)
        {
            var user = await _unitOfWork.Users.GetAsync(p => p.Id == userUpdateDto.Id);
            if (user != null)
            {
                user.UserName = userUpdateDto.UserName;
                user.Password = userUpdateDto.Password;
                user.IsActive = userUpdateDto.IsActive;
                user.UpdateDate = userUpdateDto.UpdateDate = DateTime.Now;
               
                await _unitOfWork.Users.UpdateAsync(user).ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{userUpdateDto.UserName} Ürünü Güncellendi."); 
            }
            return new Result(ResultStatus.Error, "Kayıtlı Bir Kullanıcı Bulunamadı");
        }
        
    }
}