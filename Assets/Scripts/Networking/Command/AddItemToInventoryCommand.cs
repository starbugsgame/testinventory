using Assets.Scripts.Networking.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Networking
{
    internal class AddItemToInventoryCommand : ICommand
    {
        public string Id { get; }

        public AddItemToInventoryCommand(string id)
        {
            Id = id;
        }
    }
}
