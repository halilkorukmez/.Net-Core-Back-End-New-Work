using DataAccess.Entityframework.Dal.ProductDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductDal Products { get; }
        Task<int> SaveAsync();
    }
}
