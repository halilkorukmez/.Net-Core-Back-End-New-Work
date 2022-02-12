using Core.ServicesModel;
using DataAccess.DataContext;
using Entities.PageUrls;



namespace DataAccess.Entityframework.Dal.ProductDal
{
   public class EfPageUrlDal : ServiceModel<PageUrl>, IPageUrlDal
    {
        public EfPageUrlDal(WorkerDataContext dbContext) : base(dbContext)
        {

        }

    }
}
