using Assets.Scripts.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    internal class Bag : MonoBehaviour
    {
        private IList<InventoryItem> items;

        private void Start()
        {
            var d = new CommandDispatcher();
            d.Execute(new AddItemToInventoryCommand("asdasd"));
        }

        public InventoryItem GetItem(string id)
        {
            var item = items.SingleOrDefault(x => x.Id == id);

            if (item!=null)
            {



            }

            return null;

        }

        public void AddItem(InventoryItem item) => items.Add(item);

    }
}
