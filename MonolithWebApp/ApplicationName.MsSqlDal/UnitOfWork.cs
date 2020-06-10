using ApplicationName.Core.Dal;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ApplicationName.MsSqlDal
{
    public sealed class UnitOfWork : UnitOfWorkBase<DataBaseContext>
    {
        public UnitOfWork(IDataSourceContextBuilder<DataBaseContext> contextBuilder)
            : base(contextBuilder)
        {
        }

        public override void RollBack()
        {
            var changedEntries = Context.ChangeTracker.Entries()
                .Where(x => x.State != EntityState.Unchanged).ToList();

            foreach (var entry in changedEntries)
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Unchanged;
                        break;
                }
            }

        }

        public override void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
