using System;

namespace ApplicationName.Core.Dal
{
    public interface IUnitOfWork<DataSourceContextT> : IDisposable
    {
        DataSourceContextT Context { get; }

        void SaveChanges();

        void RollBack();
    }
}
