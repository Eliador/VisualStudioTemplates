using System;

namespace ApplicationName.Core.Dal
{
    public abstract class UnitOfWorkBase<DataSourceContextT> : IUnitOfWork<DataSourceContextT> where DataSourceContextT : IDisposable
    {
        private bool disposed = false;

        protected UnitOfWorkBase(IDataSourceContextBuilder<DataSourceContextT> contextBuilder)
        {
            Context = contextBuilder.Build();
        }

        public DataSourceContextT Context { get; }

        public void Dispose()
        {
            if (!disposed)
            {
                Context.Dispose();
            }

            disposed = true;
            GC.SuppressFinalize(this);
        }

        public abstract void RollBack();

        public abstract void SaveChanges();
    }
}
