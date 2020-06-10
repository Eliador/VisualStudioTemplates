using ApplicationName.Core.Dal;
using ApplicationName.Core.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationName.MsSqlDal
{
    public class DependencyInjectionModule : IDependencyInjectionModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDataSourceContextBuilder<DataBaseContext>, DataBaseContextBuilder>();
            serviceCollection.AddScoped<IUnitOfWork<DataBaseContext>, UnitOfWork>();
        }
    }
}
