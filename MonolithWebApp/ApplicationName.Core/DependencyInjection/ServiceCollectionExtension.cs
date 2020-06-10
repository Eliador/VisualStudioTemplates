using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ApplicationName.Core.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static void BuildServiceCollection(this IServiceCollection serviceCollection)
        {
            var assemblies = GetCurrentDirectoryAssemblies();
            foreach (var assembly in assemblies)
            {
                var modules = assembly.GetTypes().Where(x => typeof(IDependencyInjectionModule).IsAssignableFrom(x) && x.IsClass);
                foreach (var module in modules)
                {
                    var moduleInstance = Activator.CreateInstance(module);
                    ((IDependencyInjectionModule)moduleInstance).Load(serviceCollection);
                }
            }
        }

        private static IEnumerable<Assembly> GetCurrentDirectoryAssemblies()
        {
            var binPath = GetBinPath();
            var assemblyFilesPaths = GetPolicyOneAssemblyFileNames(binPath);
            return assemblyFilesPaths.Select(x => Assembly.LoadFrom(x));
        }

        private static IEnumerable<string> GetPolicyOneAssemblyFileNames(string folder)
        {
            return Directory.EnumerateFiles(folder, "*.dll");
        }

        private static string GetBinPath()
        {
            var binPath = !string.IsNullOrEmpty(AppDomain.CurrentDomain.RelativeSearchPath)
                ? AppDomain.CurrentDomain.RelativeSearchPath
                : AppDomain.CurrentDomain.BaseDirectory;
            return binPath;
        }
    }
}
