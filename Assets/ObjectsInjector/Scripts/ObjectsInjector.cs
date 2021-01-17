using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectsInjector : MonoBehaviour
{

    public GameObject[] Items;

    private GameObject _currentItem;

    private Dictionary<GameObject, PositionAndRotation> _positions;

    void Start()
    {
        _positions = new Dictionary<GameObject, PositionAndRotation>();

        foreach (var item in Items)
        {
            _positions.Add(item, new PositionAndRotation()
            {
                Position = item.transform.localPosition,
                Rotation = item.transform.localRotation
            });

            Detach(item);
        }
    }

    //Attach object by index
    public void Insert(int index)
    {
        DetachCurrent();

        var item = Items[index];
        var position = _positions[item];
        item.SetActive(true);
        item.transform.localPosition = position.Position;
        item.transform.localRotation = position.Rotation;


        _currentItem = item;
    }

    public void Insert(GameObject item)
    {
        DetachCurrent();

        var position = _positions[item];
        item.SetActive(true);
        item.transform.localPosition = position.Position;
        item.transform.localRotation = position.Rotation;


        _currentItem = item;
    }

    //Attach next item
    public void InsertNext()
    {
        int index = _currentItem == null ? 0 : Items.ToList().IndexOf(_currentItem) + 1;
        Debug.Log(index);

        if (index > Items.Length - 1) index = 0;
        Insert(index);
    }

    private void Detach(GameObject item)
    {
        item.SetActive(false);
    }

    //Detach current item
    public void DetachCurrent()
    {
        if (_currentItem != null)
            Detach(_currentItem);
    }

    private struct PositionAndRotation
    {
        internal Vector3 Position;
        internal Quaternion Rotation;
    }
}
