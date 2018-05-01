using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Config_Manzana))]
public class ManzanaInspector : ConfigInspector {
    private static Vector2 scroll = Vector2.zero;
    private static bool folded = false;
    private Config_Manzana config;
    static bool editorsCreated = false;

     int  indiceSeleccionArea = 0;
     int  indiceSeleccionLote = 0;

     Config_Area seleccionArea;
     Config_Lote seleccionLote;
    private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

    private void OnEnable()
    {
        config = (Config_Manzana)target;
        editorsCreated = false;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUIStyle style = new GUIStyle(GUI.skin.box);
        
        EditorGUILayout.BeginVertical(style);

        if (GUILayout.Button("Actualizar Todo"))
        {
            config.manzana._Update();
        }
        config.centroManzana = EditorGUILayout.FloatField("Centro de Manzana:", config.centroManzana);
        base.OnInspectorGUI();

        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical(style);

        EditorGUILayout.BeginHorizontal();

        indiceSeleccionArea = EditorGUILayout.Popup(indiceSeleccionArea, config.nombreAreas);
        if (GUILayout.Button("Actualizar"))
        {
            seleccionArea.area._Update();
        }
        if (GUILayout.Button("Seleccionar"))
        {
            Selection.activeObject = seleccionArea.area.gameObject;

        }
        EditorGUILayout.EndHorizontal();
        seleccionArea = config.areas[indiceSeleccionArea];
        if (seleccionArea != null)
        {
            EditorGUILayout.LabelField("Area_" + seleccionArea.nombre);
            CreateEditor((Config_Area)config.areas[indiceSeleccionArea]).OnInspectorGUI();

        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical(style);

        EditorGUILayout.BeginHorizontal();
        indiceSeleccionLote = EditorGUILayout.Popup(indiceSeleccionLote, config.areas[indiceSeleccionArea].nombresLotes.ToArray());
        if (indiceSeleccionLote >= seleccionArea.lotes.Count)
        {
            indiceSeleccionLote = seleccionArea.lotes.Count - 1;
        }

        if (GUILayout.Button("Actualizar"))
        {
            seleccionLote.lote._Update();
        }

        if (GUILayout.Button("Seleccionar"))
        {
                       Selection.activeObject = seleccionLote.lote.gameObject;

        }
        EditorGUILayout.EndHorizontal();
        
        seleccionLote = config.areas[indiceSeleccionArea].lotes[indiceSeleccionLote];

        

        if (seleccionLote != null)
        {
            EditorGUILayout.LabelField("Lote_" + seleccionLote.nombre);
            CreateEditor((Config_Lote)config.areas[indiceSeleccionArea].lotes[indiceSeleccionLote]).OnInspectorGUI();

        }
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();


        EditorUtility.SetDirty(target);

    }




}
