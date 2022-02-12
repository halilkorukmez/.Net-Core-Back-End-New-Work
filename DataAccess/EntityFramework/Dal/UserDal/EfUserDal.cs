using Core.ServicesModel;
using DataAccess.DataContext;
using Entities.Users;


namespace DataAccess.EntityFramework.Dal.UserDal
{
    public class EfUserDal : ServiceModel<User>, IUserDal
    {
        public EfUserDal(WorkerDataContext dbContext) : base(dbContext)
        {

        }
        
    }
}