using StoreDDD.Domain.Commands.Interfaces;

namespace StoreDDD.Domain.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}