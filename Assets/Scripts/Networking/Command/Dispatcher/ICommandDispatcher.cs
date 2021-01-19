namespace Assets.Scripts.Networking.Command.Dispatcher
{
    public interface ICommandDispatcher
    {
        void Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
