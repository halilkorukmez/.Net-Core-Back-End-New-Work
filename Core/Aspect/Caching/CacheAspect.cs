using System;
using System.Linq;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IocContainer;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspect.Caching;

public class CacheAspect : MethodInterception
{
    private int _timeout;
    private readonly ICacheManager _cacheManager;

    public CacheAspect(int timeout = 60)
    {
        _timeout = timeout;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    public override void Intercept(IInvocation invocation)
    {
        //fullname contains namespace with method name
        var fullName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}";

        var arguments = invocation.Arguments.ToArray();

        var key = $"{fullName}({JsonConvert.SerializeObject(arguments)})";

        if (_cacheManager.Any(key))
            invocation.ReturnValue = _cacheManager.Get(key);
        else
        {
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _timeout);
        }
    }
}