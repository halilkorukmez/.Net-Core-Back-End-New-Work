using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IocContainer;

public interface ICoreModule
{
    void Load(IServiceCollection services);
}