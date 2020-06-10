using Microsoft.Extensions.DependencyInjection;

namespace ApplicationName.Core.DependencyInjection
{
    public interface IDependencyInjectionModule
    {
        void Load(IServiceCollection serviceCollection);
    }
}
