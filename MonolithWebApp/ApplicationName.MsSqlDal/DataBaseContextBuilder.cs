using ApplicationName.Core.Configuration;
using ApplicationName.Core.Dal;
using Microsoft.Extensions.Configuration;

namespace ApplicationName.MsSqlDal
{
    public class DataBaseContextBuilder : IDataSourceContextBuilder<DataBaseContext>
    {
        private IConfiguration _configurations;

        public DataBaseContextBuilder(IConfiguration configurations)
        {
            _configurations = configurations;
        }

        public DataBaseContext Build()
        {
            var connectionString = _configurations.GetConnectionString(ApplicationSettings.ConnectionString);
            return new DataBaseContext(connectionString);
        }
    }
}
