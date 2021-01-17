using Assets.DynamicListUI.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicList : MonoBehaviour
{
    void Start()
    {
        var adorner = FindObjectOfType<Adorner>();
        if (adorner == null)
        {
            adorner = GetComponentInChildren<Adorner>(true);
            adorner.gameObject.SetActive(true);
        }

        GetComponentInChildren<ListViewModel>().Adorner = adorner;
    }

}
