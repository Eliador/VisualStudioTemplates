using ApplicationName.Core.Cqrs;
using ApplicationName.Core.DependencyInjection;
using ApplicationName.Core.Log;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationName.Core
{
    public class DependencyInjectionModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IOperationScope, OperationScope>();
            serviceCollection.AddScoped<ICommandQueryDispatcher, CommandQueryDispatcher>();
            serviceCollection.AddScoped<IApplicationLogger, OutputApplicationLogger>();
        }
    }
}
