using Assets.Scripts.Networking;
using Assets.Scripts.Networking.Command;
using Assets.Scripts.Networking.Command.Handlers;
using Assets.Scripts.Networking.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.DI
{
    /// <summary>
    /// Mock for the DI Resolver
    /// </summary>
    public class SimpleDependencyResolver
    {
        public ICommandHandler<ICommand> ResolveHandler(ICommand command)
        {
            switch (command)
            {
                case AddItemToInventoryCommand _:
                    return new AddItemToInventoryHandler();

                case RemoveItemFromInventoryCommand _:
                    return new GetItemFromInventoryHandler();
            }

            return null;
        }
    }
}
