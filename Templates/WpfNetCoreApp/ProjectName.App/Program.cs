using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.App.Core;

namespace ProjectName.App
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var context = new CompositionContext())
            {
                Application app = new Application();

                app.Resources.Add(typeof(ServiceProvider), context.ServiceProvider);

                var window = (MainWindow)context.ServiceProvider.GetService(typeof(MainWindow));
                app.Run(window);
            }
        }
    }
}
