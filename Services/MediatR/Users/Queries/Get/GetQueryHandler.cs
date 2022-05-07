using System;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspect.Caching;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork;
using Entities.Users.UserDtos;
using MediatR;

namespace Services.MediatR.Users.Queries.Get;

[CacheAspect]
public class GetQueryHandler : IRequestHandler<GetQuery, DataResult<UserDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<DataResult<UserDto>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.Users.GetAsync(p => p.Id == request.Id);
            if (user != null)
            {
                return new DataResult<UserDto>(ResultStatus.Success, new UserDto() {
                    Name = user.Name,
                    UserName = user.Name,
                    Password = user.Password,
                    IsActive = user.IsActive,
                    Id = user.Id
                });
            }
            return new DataResult<UserDto>(ResultStatus.Error, "Kayıtlı Bir Kullanıcı Bulunamadı", null);
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
       
    }
}