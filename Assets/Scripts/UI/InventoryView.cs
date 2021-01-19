using Assets.Scripts.Events;
using Assets.Scripts.Inventory;
using Lean.Touch;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField]
        private Transform _weaponPanel;

        [SerializeField]
        private Transform _foodPanel;

        [SerializeField]
        private Transform _garbagePanel;

        private Dictionary<InventoryItemType, Transform> _itemTypePanels;
        private Dictionary<GameObject, InventoryItem> _imagesAndItems = new Dictionary<GameObject, InventoryItem>();

        private GlobalEvents _globalEvents;

        private void OnEnable()
        {
            LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
        }

        private void OnDisable()
        {
            LeanTouch.OnFingerUp -= LeanTouch_OnFingerUp;
        }

        public GameObject GetImageUnderPointer()
        {
            PointerEventData pointerData = new PointerEventData(EventSystem.current)
            {
                pointerId = -1,
            };

            pointerData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerData, results);

            var icon = results.SingleOrDefault(x => x.gameObject.name.Contains("Icon"));
            return icon.gameObject;
        }

        private void LeanTouch_OnFingerUp(LeanFinger obj)
        {
            var image = GetImageUnderPointer();
            if (image == null) return;

            var item = _imagesAndItems[image];

            _globalEvents.ItemRemovedFromBagEvent.Invoke(item);
        }

        void Awake()
        {
            _globalEvents = FindObjectOfType<GlobalEvents>();

            _itemTypePanels = new Dictionary<InventoryItemType, Transform>()
            {
                { InventoryItemType.Weapon, _weaponPanel },
                { InventoryItemType.Food, _foodPanel },
                { InventoryItemType.Garbage, _garbagePanel }
            };
        }

        /// <summary>
        /// Fill invemtory UI with icons
        /// </summary>
        /// <param name="items"></param>
        public void DrawItems(IList<InventoryItem> items)
        {
            Clear();

            foreach (var item in items)
            {
                var imageObj = new GameObject();
                imageObj.name = item.ItemName + "Icon";
                var image = imageObj.AddComponent<Image>();
                image.sprite = item.Sprite;
                imageObj.transform.SetParent(_itemTypePanels[item.Type]);
                image.rectTransform.localPosition = Vector3.zero; // Calculate position for more items
                _imagesAndItems.Add(imageObj, item); // Map image with item
            }
        }

        private void Clear()
        {
            DestroyChildren(_weaponPanel);
            DestroyChildren(_foodPanel);
            DestroyChildren(_garbagePanel);
            _imagesAndItems.Clear();
        }

        private void DestroyChildren(Transform parent)
        {
            foreach (Transform child in parent)
            {
                Destroy(child.gameObject);
            }
        }

        private void Update()
        {
            if (!Input.GetMouseButton(0)) // Show inventory only on mouse button is held down
            {
                Hide();
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }


    }
}
