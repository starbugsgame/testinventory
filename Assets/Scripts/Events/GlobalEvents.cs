using Assets.Scripts.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Events
{
    public class GlobalEvents : MonoBehaviour
    {
        public InventoryItemEvent ItemDroppedToBagEvent;
        public InventoryItemEvent ItemRemovedFromBagEvent;
        public InventoryItemEvent ItemSelectedEvent;
        public InventoryItemEvent ItemDeselectedEvent;
        public InventoryItemsChangedEvent ItemsChanged;
        public UnityEvent BagClicked;
    }

    [Serializable]
    public class InventoryItemEvent : UnityEvent<InventoryItem> { }

    [Serializable]
    public class InventoryItemsChangedEvent : UnityEvent<IList<InventoryItem>> { }
}
