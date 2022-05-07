using System.Reflection;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Utilities.IocContainer;
using DataAccess.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Services.DependencyResolvers;

public class ServicesModule : ICoreModule
{
    public void Load(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
       
        services.AddSingleton<RedisServer>();
        services.AddSingleton<ICacheManager, RedisCacheService>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}