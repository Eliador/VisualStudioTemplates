using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationName.Core.Dal
{
    public interface IUnitOfWork<DataSourceContextT> : IDisposable
    {
        DataSourceContextT Context { get; }

        void SaveChanges();

        void RollBack();
    }
}
