using Assets.Scripts.Inventory;
using Assets.Scripts.Networking.Command;
using Assets.Scripts.Networking.Command.Dispatcher;
using Assets.Scripts.Networking.Query;
using UnityEngine;

namespace Assets.Scripts.Networking
{
    public class NetworkMediator : MonoBehaviour
    {
        private ICommandDispatcher _commandDispatcher;

        private void Awake()
        {
            _commandDispatcher = new CommandDispatcher(); // Must be resolved via DI
        }

        public void SendAddItemToInventoryCommand(InventoryItem item)
        {
            if (item != null)
            {
                _commandDispatcher.Execute(new AddItemToInventoryCommand(item.Id));
            }
        }

        public void SendRemoveItemToInventoryCommand(InventoryItem item)
        {
            if (item != null)
            {
                _commandDispatcher.Execute(new RemoveItemFromInventoryCommand(item.Id));
            }
        }

    }
}
