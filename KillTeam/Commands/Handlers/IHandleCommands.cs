using System.Threading.Tasks;

namespace KillTeam.Commands.Handlers
{
    public interface IHandleCommands<TCommand>
    {
        void Handle(TCommand command);
    }
    public interface IHandleCommands<TOut, TCommand>
    {
        TOut Handle(TCommand command);
    }
}