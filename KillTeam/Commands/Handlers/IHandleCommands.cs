namespace KillTeam.Commands.Handlers
{
    public interface IHandleCommands<TCommand>
    {
        void Handle(TCommand command);
    }
}