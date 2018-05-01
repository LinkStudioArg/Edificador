using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Config_Area))]

public class AreaInspector : ConfigInspector {
    private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

    private bool folded = false;
    private Config_Area config;
    bool editorsCreated = false;

    private void OnEnable()
    {
        config = (Config_Area)target;
        editorsCreated = false;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        config.area.color = EditorGUILayout.ColorField("Color:", config.area.color);

        base.OnInspectorGUI();
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(target);
    }
}
