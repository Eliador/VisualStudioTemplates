using System;

namespace ApplicationName.Core.DependencyInjection
{
    public class OperationScope : IOperationScope
    {
        public OperationScope()
        {
            ScopeId = Guid.NewGuid();
        }

        public Guid ScopeId { get; }
    }
}
