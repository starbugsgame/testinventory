namespace Assets.Scripts.Networking.Command.Commands.Impl
{
    public class CommandBase : ICommand
    {
        public string Command { get => GetType().ToString(); }
    }
}
