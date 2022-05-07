using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Aspect.Caching;
using Core.Aspect.Loging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork;
using Entities.Users.UserDtos;
using MediatR;

namespace Services.MediatR.Users.Queries.GetList;

[LogAspect(typeof(FileLogger))]
[CacheAspect]
public class GetlistQueryHandler : IRequestHandler<GetListQuery, DataResult<UserListDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetlistQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<DataResult<UserListDto>> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await _unitOfWork.Users.GetListAsync(p => p.IsActive == true);
            if (users != null)
            {
                return new DataResult<UserListDto>(ResultStatus.Success, new UserListDto() {
                    Users = users
                });
            }
            return new DataResult<UserListDto>(ResultStatus.Error, "Kayıtlı Bir Kullanıcı Bulunamadı", null);
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
        
    }
    
}
