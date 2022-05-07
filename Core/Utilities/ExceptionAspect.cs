using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Utilities;

public class ExceptionAspect : MethodInterception
{
    public override void OnException(IInvocation invocation, System.Exception e)
    {
    }
}
