using System.Collections.Generic;
using Core.Utilities.Result.Concrete;
using Entities.Users.UserDtos;
using MediatR;

namespace Services.MediatR.Users.Queries.GetList;

public class GetListQuery : IRequest<DataResult<List<UserDto>>>
{
    
}