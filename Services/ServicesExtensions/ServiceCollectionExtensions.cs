using DataAccess.DataContext;
using DataAccess.Entityframework.Dal.ProductDal;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Services.ProductDataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ShopDataContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IProductDataService,ProductDataService>();
            serviceCollection.AddScoped<IProductDal,EfProductDal>();

           
            return serviceCollection;
           
        }
    }
}
