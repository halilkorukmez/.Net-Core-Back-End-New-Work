using Core.ServicesModel;
using DataAccess.DataContext;
using Entities;


namespace DataAccess.Entityframework.Dal.ProductDal
{
   public class EfProductDal : ServiceModel<Product>, IProductDal
    {
        public EfProductDal(ShopDataContext dbContext) : base(dbContext)
        {

        }

    }
}
