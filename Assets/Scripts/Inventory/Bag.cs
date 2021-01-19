using Assets.Scripts.Events;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Inventory
{
    internal class Bag : MonoBehaviour
    {
        public ItemTypePosition[] ItemPositions; // Anchors for different item types

        private GlobalEvents _globalEvents;
        private IList<InventoryItem> _items;

        private void Awake()
        {
            _items = new List<InventoryItem>();
            _globalEvents = FindObjectOfType<GlobalEvents>();
        }

        private void OnMouseDown()
        {
            _globalEvents.BagClicked.Invoke();
        }

        private void Update()
        {
            if (Input.GetMouseButton(0)) return;

            // Smooth snapping
            foreach (var item in _items)
            {
                item.transform.localPosition = Vector3.Lerp(item.transform.localPosition, Vector3.zero, Time.deltaTime * 10f);
                item.transform.localRotation = Quaternion.Lerp(item.transform.localRotation, Quaternion.identity, Time.deltaTime * 10f);
            }
        }

        /// <summary>
        /// Add Item to Bag on client
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(InventoryItem item)
        {
            item.DisableRigidBody();
            var anchor = ItemPositions.Single(x => x.ItemType == item.Type).Transform;
            item.transform.SetParent(anchor);
            item.IsInBag = true;
            if (!_items.Contains(item))
            {
                _items.Add(item);
                _globalEvents.ItemsChanged.Invoke(_items);
            }
        }

        /// <summary>
        /// Remove Item from Bag on client
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(InventoryItem item)
        {
            item.EnableRigidBody();
            item.transform.SetParent(null);
            item.IsInBag = false;
            if (_items.Contains(item))
            {
                _items.Remove(item);
                _globalEvents.ItemsChanged.Invoke(_items);
            }
        }
    }
}
