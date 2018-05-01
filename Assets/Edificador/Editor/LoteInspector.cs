using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Config_Lote))]

public class LoteInspector : ConfigInspector {
    private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

    private  bool folded = false;
    private Config_Lote config;
    private void OnEnable()
    {
        config = (Config_Lote)target;
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        base.OnInspectorGUI();


        /*
        config.rotate = EditorGUILayout.ToggleLeft("Rotar180", config.rotate);
        
        config.retiroFrente = EditorGUILayout.FloatField("Retiro Frente", config.retiroFrente);
        EditorGUILayout.BeginHorizontal();

        config.retiroFrenteAleatorio = EditorGUILayout.Vector2Field("Aleatorio", config.retiroFrenteAleatorio);
        if (GUILayout.Button("Random"))
        {
            config.retiroFrente = Random.Range(config.retiroFrenteAleatorio.x, config.retiroFrenteAleatorio.y);
        }
        EditorGUILayout.EndHorizontal();
        config.retiroFondo = EditorGUILayout.FloatField("Retiro Fondo", config.retiroFondo);
        EditorGUILayout.BeginHorizontal();

        config.retiroFondoAleatorio = EditorGUILayout.Vector2Field("Aleatorio", config.retiroFondoAleatorio);
        if (GUILayout.Button("Random"))
        {
            config.retiroFondo = Random.Range(config.retiroFondoAleatorio.x, config.retiroFondoAleatorio.y);
        }
        EditorGUILayout.EndHorizontal();
        config.altura = EditorGUILayout.FloatField("Altura", config.altura);
        EditorGUILayout.BeginHorizontal();

        config.alturaAleatorio = EditorGUILayout.Vector2Field("Aleatorio", config.alturaAleatorio);
        if (GUILayout.Button("Random"))
        {
            config.altura = Random.Range(config.alturaAleatorio.x, config.alturaAleatorio.y);
        }
        EditorGUILayout.EndHorizontal(); serializedObject.ApplyModifiedProperties();

        config.tipo = (Config_Lote.Tipo)EditorGUILayout.EnumPopup("Tipo:", config.tipo);
        if (config.tipo == Config_Lote.Tipo.TIPO1)
        {
            GUILayout.Label("Hueco:");
            config.profundidad = EditorGUILayout.FloatField("Profundidad:", config.profundidad);
            EditorGUILayout.BeginHorizontal();

            config.aleatorioProfundidad = EditorGUILayout.Vector2Field("Aleatorio", config.aleatorioProfundidad);
            if (GUILayout.Button("Random"))
            {
                config.profundidad = Random.Range(config.aleatorioProfundidad.x, config.aleatorioProfundidad.y);
            }
            EditorGUILayout.EndHorizontal();
            config.longitud = EditorGUILayout.FloatField("Longitud:", config.longitud);
            EditorGUILayout.BeginHorizontal();
            config.aleatorioLongitud = EditorGUILayout.Vector2Field("Aleatorio", config.aleatorioLongitud);
            if (GUILayout.Button("Random"))
            {
                config.longitud = Random.Range(config.aleatorioLongitud.x, config.aleatorioLongitud.y);
            }
            EditorGUILayout.EndHorizontal();

        }*/


        EditorUtility.SetDirty(target);


    }
}
