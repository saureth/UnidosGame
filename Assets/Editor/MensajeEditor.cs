using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Mensajero))]
public class MensajeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Mensajero t = (Mensajero)target;
        if (t.mensaje < 0 || t.mensaje > Mensajes.GetSingleton().mensajes.Length-1)
        {
            GUIStyle s = new GUIStyle();
            s.normal.textColor = Color.red;
            GUILayout.Label("NO SE ENCUENTRA ESTE MENSAJE",s);
        }
        else
        {
            GUILayout.Label("--> " + Mensajes.GetSingleton().mensajes[t.mensaje].español);
        }
    }
}
