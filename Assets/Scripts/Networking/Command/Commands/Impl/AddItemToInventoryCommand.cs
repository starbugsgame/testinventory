using Assets.Scripts.Networking.Command.Commands.Impl;

namespace Assets.Scripts.Networking
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
