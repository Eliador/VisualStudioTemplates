namespace ApplicationName.Core.Cqrs
{
    public interface ICommandHandler<TCommandDefinition>
    {
        void Handle(TCommandDefinition parameters);
    }
}
