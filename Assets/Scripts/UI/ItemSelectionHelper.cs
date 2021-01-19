using Assets.Scripts.Events;
using Assets.Scripts.Inventory;
using Lean.Touch;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ItemSelectionHelper : MonoBehaviour
    {
        public LeanSelectable SelectedItem => _selectables.FirstOrDefault(x => x.IsSelected);
        private IEnumerable<LeanSelectable> _selectables;
        private GlobalEvents _globalEvents;

        private void Awake()
        {
            LeanSelectable.OnDeselectGlobal += LeanSelectable_OnDeselectGlobal;
            LeanSelectable.OnSelectGlobal += LeanSelectable_OnSelectGlobal;

            _selectables = FindObjectsOfType<LeanSelectable>();

            _globalEvents = FindObjectOfType<GlobalEvents>();
        }

        private void LeanSelectable_OnSelectGlobal(LeanSelectable arg1, LeanFinger arg2)
        {
            _globalEvents.ItemSelectedEvent.Invoke(arg1.GetComponent<InventoryItem>());
        }

        private void LeanSelectable_OnDeselectGlobal(LeanSelectable obj)
        {
            var item = obj.GetComponent<InventoryItem>();

            _globalEvents.ItemDeselectedEvent.Invoke(item);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var raycasts = Physics.RaycastAll(ray, 100);
            {
                if (raycasts.Any(x => x.collider.tag == "Bag")) // If pointer is over bag
                {
                    _globalEvents.ItemDroppedToBagEvent.Invoke(item);
                    return;
                }
            }

            if (item.IsInBag) _globalEvents.ItemRemovedFromBagEvent.Invoke(item);
        }
    }
}
