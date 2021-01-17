using Assets.DynamicListUI.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ListViewModel))]
public class ListViewModelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ListViewModel listViewModel = (ListViewModel)target;
        if (GUILayout.Button("Preview"))
        {
            listViewModel.Init();
            listViewModel.GenerateList();
        }

        if (GUILayout.Button("Reset"))
        {
            listViewModel.ResetInEditor();
        }
    }
}
