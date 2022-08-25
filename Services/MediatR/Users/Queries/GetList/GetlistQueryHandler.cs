using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Aspect.Caching;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork;
using Entities.Users.UserDtos;
using MediatR;

namespace Services.MediatR.Users.Queries.GetList;


public class GetlistQueryHandler : IRequestHandler<GetListQuery, DataResult<List<UserDto>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetlistQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<DataResult<List<UserDto>>> Handle(GetListQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var users = await _unitOfWork.Users.GetListAsync(p => p.IsActive == true);
            if (users == null)
                return new DataResult<List<UserDto>>(ResultStatus.Error, "Kayıtlı Bir Kullanıcı Bulunamadı", null);
            return new DataResult<List<UserDto>>(ResultStatus.Success, _mapper.Map<List<UserDto>>(users));
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
        
    }
    
}
