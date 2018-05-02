using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Lote))]

public class LoteInspector : Editor
{
    private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

    private  bool folded = false;
    private Lote lote;
    private void OnEnable()
    {
        lote = (Lote)target;
    }
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.BeginHorizontal();
        lote.configuracion.rotate = EditorGUILayout.ToggleLeft("Rotar180", lote.configuracion.rotate);
        lote.configuracion.excluir = EditorGUILayout.Toggle("Excluir", lote.configuracion.excluir);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        lote.configuracion.retiroFrente = EditorGUILayout.FloatField("Retiro Frente", lote.configuracion.retiroFrente);
        lote.configuracion.retiroFrenteRPT = EditorGUILayout.ToggleLeft("RPT", lote.configuracion.retiroFrenteRPT);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        lote.configuracion.retiroFrenteAleatorio = EditorGUILayout.Vector2Field("Aleatorio", lote.configuracion.retiroFrenteAleatorio);
        if (GUILayout.Button("Random"))
        {
            lote.configuracion.retiroFrente = Random.Range(lote.configuracion.retiroFrenteAleatorio.x, lote.configuracion.retiroFrenteAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        lote.configuracion.retiroFondo = EditorGUILayout.FloatField("Retiro Fondo", lote.configuracion.retiroFondo);
        lote.configuracion.retiroFondoRPT = EditorGUILayout.ToggleLeft("RPT", lote.configuracion.retiroFondoRPT);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        lote.configuracion.retiroFondoAleatorio = EditorGUILayout.Vector2Field("Aleatorio", lote.configuracion.retiroFondoAleatorio);
        if (GUILayout.Button("Random"))
        {
            lote.configuracion.retiroFondo = Random.Range(lote.configuracion.retiroFondoAleatorio.x, lote.configuracion.retiroFondoAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        lote.configuracion.altura = EditorGUILayout.FloatField("Altura", lote.configuracion.altura);
        lote.configuracion.alturaRPT = EditorGUILayout.ToggleLeft("RPT", lote.configuracion.alturaRPT);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        lote.configuracion.alturaAleatorio = EditorGUILayout.Vector2Field("Aleatorio", lote.configuracion.alturaAleatorio);
        if (GUILayout.Button("Random"))
        {
            lote.configuracion.altura = Random.Range(lote.configuracion.alturaAleatorio.x, lote.configuracion.alturaAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        lote.configuracion.tipo = (Config.Tipo)EditorGUILayout.EnumPopup("Tipo:", lote.configuracion.tipo);
        if (lote.configuracion.tipo == Config.Tipo.TIPO1)
        {
            GUILayout.Label("Hueco:");
            lote.configuracion.profundidad = EditorGUILayout.FloatField("Profundidad:", lote.configuracion.profundidad);
            EditorGUILayout.BeginHorizontal();

            lote.configuracion.aleatorioProfundidad = EditorGUILayout.Vector2Field("Aleatorio", lote.configuracion.aleatorioProfundidad);
            if (GUILayout.Button("Random"))
            {
                lote.configuracion.profundidad = Random.Range(lote.configuracion.aleatorioProfundidad.x, lote.configuracion.aleatorioProfundidad.y);
            }
            EditorGUILayout.EndHorizontal();
            lote.configuracion.longitud = EditorGUILayout.FloatField("Longitud:", lote.configuracion.longitud);
            EditorGUILayout.BeginHorizontal();
            lote.configuracion.aleatorioLongitud = EditorGUILayout.Vector2Field("Aleatorio", lote.configuracion.aleatorioLongitud);
            if (GUILayout.Button("Random"))
            {
                lote.configuracion.longitud = Random.Range(lote.configuracion.aleatorioLongitud.x, lote.configuracion.aleatorioLongitud.y);
            }
            EditorGUILayout.EndHorizontal();

        }

        EditorUtility.SetDirty(target);
        EditorUtility.SetDirty(((Lote)target).configuracion);

        //DrawDefaultInspector();
    }
}
