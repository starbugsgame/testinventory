using Assets.DynamicListUI.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSourceSetter : MonoBehaviour
{
    void Start()
    {
        var listViewModel = FindObjectOfType<ListViewModel>();
        var items = new List<ListItemViewModel>();

        for (int i = 0; i < 100; i++)
        {
            items.Add(new ListItemViewModel()
            {
                Color = UnityEngine.Random.ColorHSV()
            });
        }

        listViewModel.SetItemsSource(items.ToArray());

    }

}
