using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Networking.Query
{
    internal class GetItemFromInventoryCommand
    {
        public string Id { get; }

        public GetItemFromInventoryCommand(string id)
        {
            Id = id;
        }
    }
}
