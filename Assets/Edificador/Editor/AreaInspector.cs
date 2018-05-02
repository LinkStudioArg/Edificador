using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Area))]

public class AreaInspector : Editor
{
    private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

    private bool folded = false;
    private Area area;
    bool editorsCreated = false;

    private void OnEnable()
    {
        area = (Area)target;
        editorsCreated = false;
    }

    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();

        serializedObject.Update();
        area.configuracion.color = EditorGUILayout.ColorField("Color:", area.configuracion.color);

        EditorGUILayout.BeginHorizontal();
        area.configuracion.rotate = EditorGUILayout.ToggleLeft("Rotar180", area.configuracion.rotate);
        area.configuracion.excluir = EditorGUILayout.Toggle("Excluir", area.configuracion.excluir);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        area.configuracion.retiroFrente = EditorGUILayout.FloatField("Retiro Frente", area.configuracion.retiroFrente);
        area.configuracion.retiroFrenteRPT = EditorGUILayout.ToggleLeft("RPT", area.configuracion.retiroFrenteRPT);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        area.configuracion.retiroFrenteAleatorio = EditorGUILayout.Vector2Field("Aleatorio", area.configuracion.retiroFrenteAleatorio);
        if (GUILayout.Button("Random"))
        {
            area.configuracion.retiroFrente = Random.Range(area.configuracion.retiroFrenteAleatorio.x, area.configuracion.retiroFrenteAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        area.configuracion.retiroFondo = EditorGUILayout.FloatField("Retiro Fondo", area.configuracion.retiroFondo);
        area.configuracion.retiroFondoRPT = EditorGUILayout.ToggleLeft("RPT", area.configuracion.retiroFondoRPT);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        area.configuracion.retiroFondoAleatorio = EditorGUILayout.Vector2Field("Aleatorio", area.configuracion.retiroFondoAleatorio);
        if (GUILayout.Button("Random"))
        {
            area.configuracion.retiroFondo = Random.Range(area.configuracion.retiroFondoAleatorio.x, area.configuracion.retiroFondoAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        area.configuracion.altura = EditorGUILayout.FloatField("Altura", area.configuracion.altura);
        area.configuracion.alturaRPT = EditorGUILayout.ToggleLeft("RPT", area.configuracion.alturaRPT);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        area.configuracion.alturaAleatorio = EditorGUILayout.Vector2Field("Aleatorio", area.configuracion.alturaAleatorio);
        if (GUILayout.Button("Random"))
        {
            area.configuracion.altura = Random.Range(area.configuracion.alturaAleatorio.x, area.configuracion.alturaAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        area.configuracion.tipo = (Config.Tipo)EditorGUILayout.EnumPopup("Tipo:", area.configuracion.tipo);
        if (area.configuracion.tipo == Config.Tipo.TIPO1)
        {
            GUILayout.Label("Hueco:");
            area.configuracion.profundidad = EditorGUILayout.FloatField("Profundidad:", area.configuracion.profundidad);
            EditorGUILayout.BeginHorizontal();

            area.configuracion.aleatorioProfundidad = EditorGUILayout.Vector2Field("Aleatorio", area.configuracion.aleatorioProfundidad);
            if (GUILayout.Button("Random"))
            {
                area.configuracion.profundidad = Random.Range(area.configuracion.aleatorioProfundidad.x, area.configuracion.aleatorioProfundidad.y);
            }
            EditorGUILayout.EndHorizontal();
            area.configuracion.longitud = EditorGUILayout.FloatField("Longitud:", area.configuracion.longitud);
            EditorGUILayout.BeginHorizontal();
            area.configuracion.aleatorioLongitud = EditorGUILayout.Vector2Field("Aleatorio", area.configuracion.aleatorioLongitud);
            if (GUILayout.Button("Random"))
            {
                area.configuracion.longitud = Random.Range(area.configuracion.aleatorioLongitud.x, area.configuracion.aleatorioLongitud.y);
            }
            EditorGUILayout.EndHorizontal();

        }
        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(target);
        EditorUtility.SetDirty(((Area)target).configuracion);

    }
}
