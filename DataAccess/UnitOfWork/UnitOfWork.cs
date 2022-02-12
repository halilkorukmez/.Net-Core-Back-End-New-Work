using DataAccess.DataContext;
using DataAccess.Entityframework.Dal.ProductDal;
using System.Threading.Tasks;
using DataAccess.EntityFramework.Dal.UserDal;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkerDataContext _context;
        private EfPageUrlDal _efPageUrlDal;
        private EfUserDal _efUserDal;  
        
        public UnitOfWork(WorkerDataContext context)
        {
            _context = context;
        
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public IPageUrlDal PageUrl => _efPageUrlDal ?? new EfPageUrlDal(_context);
        public IUserDal Users => _efUserDal ?? new EfUserDal(_context);
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
