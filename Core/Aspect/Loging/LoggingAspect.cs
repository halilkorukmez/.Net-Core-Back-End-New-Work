using System;
using System.Collections.Generic;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities;
using Core.Utilities.Interceptors;
using PostSharp.Aspects;

namespace Core.Aspect.Loging;

public class LogAspect : MethodInterception
{
    private LoggerServiceBase _loggerServiceBase;

    public LogAspect(Type loggerServiceType)
    {
        if (loggerServiceType.BaseType != typeof(LoggerServiceBase))
        {
            throw new AspectException(AspectMessages.WrongLoggerType);
        }

        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceType);
    }

    public override void OnBefore(IInvocation invocation)
    {
        var logDetail = GetLogDetail(invocation);
        _loggerServiceBase.Info(logDetail);
    }

    private LogDetail GetLogDetail(IInvocation invocation)
    {
        var logParameters = new List<LogParameter>();

        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            var logParameter = new LogParameter
            {
                Type = invocation.Arguments[i].GetType().Name,
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i]
            };

            logParameters.Add(logParameter);
        }

        var logDetail = new LogDetail
        {
            LogParameters = logParameters,
            MethodName = $"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"
        };

        return logDetail;
    }
}