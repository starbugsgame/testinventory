using Assets.Scripts.Networking.Command.Commands.Impl;

namespace Assets.Scripts.Networking.Query
{
    internal class RemoveItemFromInventoryCommand: CommandBase
    {
        public string Id { get; }

        public RemoveItemFromInventoryCommand(string id)
        {
            Id = id;
        }
    }
}
