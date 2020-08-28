using System;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationName.Core.Cqrs
{
    public class CommandQueryDispatcher : ICommandQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandQueryDispatcher(IServiceProvider servicesProvider)
        {
            _serviceProvider = servicesProvider;
        }

        public void HandleCommand<TCommandDefinition>(TCommandDefinition parameters)
        {
            var command = _serviceProvider.GetService<ICommandHandler<TCommandDefinition>>();

            command.Handle(parameters);
        }

        public TResult HandleQuery<TQueryDefinition, TResult>(TQueryDefinition parameters)
        {
            var query = _serviceProvider.GetService<IQueryHandler<TQueryDefinition, TResult>>();

            return query.Handle(parameters);
        }
    }
}
