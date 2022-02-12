using DataAccess.Entityframework.Dal.ProductDal;
using DataAccess.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using Services.PageUrlsDataServices;
using DataAccess.EntityFramework.Dal.UserDal;
using Services.LoginServices;
using Services.TokenServices;
using Services.UserDataServices;

namespace Services.ServicesExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
           
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<IPageUrlsDataService,PageUrlsDataService>();
            serviceCollection.AddScoped<IUserDataService,UserDataService>();
            serviceCollection.AddScoped<IPageUrlDal,EfPageUrlDal>();
            serviceCollection.AddScoped<IUserDal,EfUserDal>();
            serviceCollection.AddScoped<ITokenService , TokenService>();
            serviceCollection.AddScoped<ILoginService , LoginService>();
            

            
            return serviceCollection;
           
        }
    }
}
