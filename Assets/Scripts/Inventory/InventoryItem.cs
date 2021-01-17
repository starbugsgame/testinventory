using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    internal class InventoryItem : MonoBehaviour
    {
        [SerializeField]
        private string id;

        [SerializeField]
        private string itemName;

        [SerializeField]
        private float weight;

        [SerializeField]
        private InventoryItemType type;

        public string Id { get => id; private set => id = value; }
        public string ItemName { get => itemName; private set => itemName = value; }
        public float Weight { get => weight; private set => weight = value; }
        internal InventoryItemType Type { get => type; private set => type = value; }
    }
}
