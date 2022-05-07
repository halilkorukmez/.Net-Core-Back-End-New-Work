using System;
using System.Threading.Tasks;
using DataAccess.EntityFramework.Dal.UserDal;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IUserDal Users { get; }
        Task<int> SaveAsync();
    }
}
