namespace ApplicationName.Core.Cqrs
{
    public interface ICommandQueryDispatcher
    {
        TResult HandleQuery<TQueryDefinition, TResult>(TQueryDefinition parameters);

        void HandleCommand<TCommandDefinition>(TCommandDefinition parameters);
    }
}
