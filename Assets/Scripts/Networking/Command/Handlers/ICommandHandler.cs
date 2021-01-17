namespace Assets.Scripts.Networking.Command.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
