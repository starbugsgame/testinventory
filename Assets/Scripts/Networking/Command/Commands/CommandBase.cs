namespace Assets.Scripts.Networking.Command.Commands
{
    public class CommandBase : ICommand
    {
        public string Command { get => GetType().ToString(); }
    }
}
