using ApplicationName.Core.Cqrs;
using ApplicationName.Core.DependencyInjection;
using ApplicationName.Core.Log;
using Microsoft.Extensions.DependencyInjection;
using NLog;

namespace ApplicationName.Core
{
    public class DependencyInjectionModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IOperationScope, OperationScope>();
            serviceCollection.AddScoped<ICommandQueryDispatcher, CommandQueryDispatcher>();
            serviceCollection.AddScoped<IApplicationLogger, ApplicationLogger>();
            serviceCollection.AddScoped<ILogger>(serviceProvider => LogManager.GetCurrentClassLogger());
        }
    }
}
