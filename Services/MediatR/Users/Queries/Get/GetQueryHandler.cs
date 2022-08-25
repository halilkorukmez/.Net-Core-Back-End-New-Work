using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
    private readonly IMapper _mapper;
    public GetQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<DataResult<UserDto>> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _unitOfWork.Users.GetAsync(p => p.Id == request.Id);
            if (user == null)
              return new DataResult<UserDto>(ResultStatus.Error, "Kayıtlı Bir Kullanıcı Bulunamadı", null);
            return new DataResult<UserDto>(ResultStatus.Success, _mapper.Map<UserDto>(user));
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
       
    }
}