using System;
using Microsoft.Extensions.DependencyInjection;
using WpfNetCoreProjectName.Windows.ViewModels;

namespace WpfNetCoreProjectName.Core
{
    public class CompositionContext : IDisposable
    {
        public ServiceProvider ServiceProvider { get; }

        public CompositionContext()
        {
            var serviceCollection = new ServiceCollection();
            SetupDependencies(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        public void Dispose()
        {
            ServiceProvider.Dispose();
        }

        private static void SetupDependencies(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<MainWindow>();

            serviceCollection.AddTransient<MainWindowViewModel>();
        }
    }
}
