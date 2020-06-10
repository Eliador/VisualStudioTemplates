using System;

namespace ApplicationName.Core.DependencyInjection
{
    public interface IOperationScope
    {
        Guid ScopeId { get; }
    }
}
