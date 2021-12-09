using DataAccess.DataContext;
using DataAccess.Entityframework.Dal.ProductDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ShopDataContext _context;
        private EfProductDal _efProductDal;


     

        public UnitOfWork(ShopDataContext context)
        {
            _context = context;
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public IProductDal Products => _efProductDal ?? new EfProductDal(_context);

        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
