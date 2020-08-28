using Microsoft.EntityFrameworkCore;

namespace ApplicationName.MsSqlDal
{
    public class DataBaseContext : DbContext
    {
        private readonly string _connectionString;

        public DataBaseContext(string connectionString)
        {
            _connectionString = connectionString;

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
