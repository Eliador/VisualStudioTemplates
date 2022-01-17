using System;

namespace ApplicationName.Core.Dal
{
    public abstract class UnitOfWorkBase<TDataSourceContext> : IUnitOfWork<TDataSourceContext> where TDataSourceContext : IDisposable
    {
        private bool disposed = false;

        protected UnitOfWorkBase(IDataSourceContextBuilder<TDataSourceContext> contextBuilder)
        {
            Context = contextBuilder.Build();
        }

        public TDataSourceContext Context { get; }

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
