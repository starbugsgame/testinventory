using Assets.DynamicListUI.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropArea : MonoBehaviour, IDropHandler
{
    private ListViewModel _listViewModel;

    void Start()
    {
        _listViewModel = GetComponentInChildren<ListViewModel>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var button = eventData.pointerDrag.GetComponent<Button>();

        if (button == null) return;

        var sourceContainer = button.GetComponentInParent<ListViewModel>();

        if (sourceContainer == null || sourceContainer == _listViewModel) return;

        var item = sourceContainer.FindViewModelItemByButton(button);

        _listViewModel.AddItem(item);

        sourceContainer.RemoveItem(item);
    }
}
