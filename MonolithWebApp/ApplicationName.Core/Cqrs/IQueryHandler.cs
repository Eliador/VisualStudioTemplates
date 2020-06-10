namespace ApplicationName.Core.Cqrs
{
    public interface IQueryHandler<TQueryDefinition, TResult>
    {
        TResult Handle(TQueryDefinition parameters);
    }
}
