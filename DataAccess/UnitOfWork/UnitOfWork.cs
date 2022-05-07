using DataAccess.DataContext;
using System.Threading.Tasks;
using DataAccess.EntityFramework.Dal.UserDal;

namespace DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WorkerDataContext _context;
        private EfUserDal _efUserDal;  
        
        public UnitOfWork(WorkerDataContext context)
        {
            _context = context;
        
        }
        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }
        
        public IUserDal Users => _efUserDal ?? new EfUserDal(_context);
        public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    }
}
