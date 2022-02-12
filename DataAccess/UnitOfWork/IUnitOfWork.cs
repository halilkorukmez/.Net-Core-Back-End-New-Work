using DataAccess.Entityframework.Dal.ProductDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.EntityFramework.Dal.UserDal;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IPageUrlDal PageUrl { get; }
        IUserDal Users { get; }
        Task<int> SaveAsync();
    }
}
