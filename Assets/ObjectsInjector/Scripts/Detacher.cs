using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detacher : MonoBehaviour
{

    public void DetachAll()
    {
        var injectors = GetComponentsInChildren<ObjectsInjector>();

        foreach (var item in injectors)
        {
            item.DetachCurrent();
        }
    }

}
