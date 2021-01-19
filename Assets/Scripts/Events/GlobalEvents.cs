using Assets.Scripts.Inventory;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    public class GlobalEvents : MonoBehaviour
    {
        public UnityEvent<InventoryItem> ItemDroppedToBagEvent;
        public UnityEvent<InventoryItem> ItemRemovedFromBagEvent;
        public UnityEvent<InventoryItem> ItemSelectedEvent;
        public UnityEvent<InventoryItem> ItemDeselectedEvent;
        public UnityEvent<IList<InventoryItem>> ItemsChanged;
        public UnityEvent BagClicked;
    }
}
