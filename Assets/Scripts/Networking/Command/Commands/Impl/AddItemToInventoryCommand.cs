namespace Assets.Scripts.Networking.Command.Commands.Impl
{
    internal class AddItemToInventoryCommand : CommandBase
    {
        public string Id { get; }

        public AddItemToInventoryCommand(string id)
        {
            Id = id;
        }
    }
}
