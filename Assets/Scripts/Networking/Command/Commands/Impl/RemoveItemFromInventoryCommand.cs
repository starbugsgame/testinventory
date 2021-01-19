namespace Assets.Scripts.Networking.Command.Commands.Impl
{
    internal class RemoveItemFromInventoryCommand : CommandBase
    {
        public string Id { get; }

        public RemoveItemFromInventoryCommand(string id)
        {
            Id = id;
        }
    }
}
