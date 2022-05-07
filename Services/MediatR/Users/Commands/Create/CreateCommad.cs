using System;
using System.ComponentModel.DataAnnotations;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Users.UserDtos;
using MediatR;

namespace Services.MediatR.Users.Commands.Create;

public class CreateCommad : IRequest<IResult>
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public Guid Id { get; set; }
    public bool IsActive { get; set; }
}