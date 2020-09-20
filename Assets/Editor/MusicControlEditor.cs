using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MusicControl))]
public class MusicControlEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MusicControl m = (MusicControl)target;
        if (GUILayout.Button("Serializar"))
        {
            m.Serialize();
        }
        if (GUILayout.Button("Deserializar"))
        {
            m.Deserialize();
        }
        base.OnInspectorGUI();
    }
}