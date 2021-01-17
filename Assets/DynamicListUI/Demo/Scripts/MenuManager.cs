using System.Collections;
using System.Collections.Generic;
using Assets.DynamicListUI.Scripts;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    private ListViewModel _dynamicList;

    void Start()
    {
        _dynamicList = FindObjectOfType<ListViewModel>();
        _dynamicList.ItemSelected += DynamicList_ItemSelected;
        _dynamicList.ItemDragEnded += DynamicList_ItemDragEnded;
    }

    private void DynamicList_ItemDragEnded(object sender, DragEndedEventArgs args)
    {
        var injector = args.Item.GetComponentInParent<ObjectsInjector>();
        injector.Insert(args.Item.gameObject);
    }

    private void DynamicList_ItemSelected(object sender, ListItemViewModel args)
    {
        var injector = args.GetComponentInParent<ObjectsInjector>();
        injector.Insert(args.gameObject);
    }

}
