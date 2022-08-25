using System.Reflection;
using AutoMapper;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Redis;
using Core.Utilities.IocContainer;
using DataAccess.UnitOfWork;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Services.AutoMapper.Profiles;

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

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfiles());
        });
        var mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}