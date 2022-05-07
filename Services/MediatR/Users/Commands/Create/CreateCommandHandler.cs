using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Core.Aspect.Loging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.ComplexTypes;
using Core.Utilities.Result.Concrete;
using DataAccess.UnitOfWork;
using Entities.Users;
using MediatR;

namespace Services.MediatR.Users.Commands.Create;

[LogAspect(typeof(FileLogger))]
public class CreateCommandHandler : IRequestHandler<CreateCommad, IResult>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public CreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IResult> Handle(CreateCommad request, CancellationToken cancellationToken)
    {
        try
        {
            var users = _mapper.Map<User>(request);
            if (users != null)
            {
                await _unitOfWork.Users.AddAsync(users)
                    .ContinueWith(t => _unitOfWork.SaveAsync());
                return new Result(ResultStatus.Success, $"{users.Name} Adlı Kullanıcı Başarıyla Eklenmiştir.");
            }
            return new Result(ResultStatus.Error, "Eklenmedi");
        }
        catch (Exception e)
        {
            throw new ArgumentException(e.Message);
        }
     
    }
}
