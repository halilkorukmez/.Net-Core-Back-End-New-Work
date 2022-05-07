using System;
using Core.Utilities.Result.Concrete;
using Entities.Users.UserDtos;
using MediatR;

namespace Services.MediatR.Users.Queries.Get;

public class GetQuery : IRequest<DataResult<UserDto>>
{
    public Guid Id { get; set; }
}