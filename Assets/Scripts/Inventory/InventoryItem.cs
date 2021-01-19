using UnityEngine;

namespace Assets.Scripts.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField]
        private string _id;

        [SerializeField]
        private string _itemName;

        [SerializeField]
        private float _weight;

        [SerializeField]
        private InventoryItemType _type;

        public Sprite Sprite;

        public bool IsInBag { get; set; }

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public string Id { get => _id; private set => _id = value; }
        public string ItemName { get => _itemName; private set => _itemName = value; }
        public float Weight { get => _weight; private set => _weight = value; }
        internal InventoryItemType Type { get => _type; private set => _type = value; }

        public void DisableRigidBody()
        {
            _rigidbody.isKinematic = true;
        }

        public void EnableRigidBody()
        {
            _rigidbody.isKinematic = false;
        }
    }
}
