using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Manzana))]
public class ManzanaInspector : Editor {
    private static Vector2 scroll = Vector2.zero;
    private static bool folded = false;
    private Manzana manzana;
    static bool editorsCreated = false;

    static int  indiceSeleccionArea = 0;
    static int indiceSeleccionLote = 0;

    static Area seleccionArea;
    static Lote seleccionLote;
    private static readonly string[] _dontIncludeMe = new string[] { "m_Script" };

    private void OnEnable()
    {
        manzana = (Manzana)target;
        editorsCreated = false;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        GUIStyle style = new GUIStyle(GUI.skin.box);
        
        EditorGUILayout.BeginVertical(style);

        if (GUILayout.Button("Actualizar Todo"))
        {
            manzana._Update();
        }
        manzana.configuracion.centroManzana = EditorGUILayout.FloatField("Centro de Manzana:", manzana.configuracion.centroManzana);

        EditorGUILayout.BeginHorizontal();
        manzana.configuracion.rotate = EditorGUILayout.ToggleLeft("Rotar180", manzana.configuracion.rotate);
        manzana.configuracion.excluir = EditorGUILayout.Toggle("Excluir", manzana.configuracion.excluir);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        manzana.configuracion.retiroFrente = EditorGUILayout.FloatField("Retiro Frente", manzana.configuracion.retiroFrente);
        manzana.configuracion.retiroFrenteRPT = EditorGUILayout.ToggleLeft("RPT", manzana.configuracion.retiroFrenteRPT);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        manzana.configuracion.retiroFrenteAleatorio = EditorGUILayout.Vector2Field("Aleatorio", manzana.configuracion.retiroFrenteAleatorio);
        if (GUILayout.Button("Random"))
        {
            manzana.configuracion.retiroFrente = Random.Range(manzana.configuracion.retiroFrenteAleatorio.x, manzana.configuracion.retiroFrenteAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        manzana.configuracion.retiroFondo = EditorGUILayout.FloatField("Retiro Fondo", manzana.configuracion.retiroFondo);
        manzana.configuracion.retiroFondoRPT = EditorGUILayout.ToggleLeft("RPT", manzana.configuracion.retiroFondoRPT);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        manzana.configuracion.retiroFondoAleatorio = EditorGUILayout.Vector2Field("Aleatorio", manzana.configuracion.retiroFondoAleatorio);
        if (GUILayout.Button("Random"))
        {
            manzana.configuracion.retiroFondo = Random.Range(manzana.configuracion.retiroFondoAleatorio.x, manzana.configuracion.retiroFondoAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        manzana.configuracion.altura = EditorGUILayout.FloatField("Altura", manzana.configuracion.altura);
        manzana.configuracion.alturaRPT = EditorGUILayout.ToggleLeft("RPT", manzana.configuracion.alturaRPT);

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();

        manzana.configuracion.alturaAleatorio = EditorGUILayout.Vector2Field("Aleatorio", manzana.configuracion.alturaAleatorio);
        if (GUILayout.Button("Random"))
        {
            manzana.configuracion.altura = Random.Range(manzana.configuracion.alturaAleatorio.x, manzana.configuracion.alturaAleatorio.y);
        }

        EditorGUILayout.EndHorizontal();
        manzana.configuracion.tipo = (Config.Tipo)EditorGUILayout.EnumPopup("Tipo:", manzana.configuracion.tipo);
        if (manzana.configuracion.tipo == Config.Tipo.TIPO1)
        {
            GUILayout.Label("Hueco:");
            manzana.configuracion.profundidad = EditorGUILayout.FloatField("Profundidad:", manzana.configuracion.profundidad);
            EditorGUILayout.BeginHorizontal();

            manzana.configuracion.aleatorioProfundidad = EditorGUILayout.Vector2Field("Aleatorio", manzana.configuracion.aleatorioProfundidad);
            if (GUILayout.Button("Random"))
            {
                manzana.configuracion.profundidad = Random.Range(manzana.configuracion.aleatorioProfundidad.x, manzana.configuracion.aleatorioProfundidad.y);
            }
            EditorGUILayout.EndHorizontal();
            manzana.configuracion.longitud = EditorGUILayout.FloatField("Longitud:", manzana.configuracion.longitud);
            EditorGUILayout.BeginHorizontal();
            manzana.configuracion.aleatorioLongitud = EditorGUILayout.Vector2Field("Aleatorio", manzana.configuracion.aleatorioLongitud);
            if (GUILayout.Button("Random"))
            {
                manzana.configuracion.longitud = Random.Range(manzana.configuracion.aleatorioLongitud.x, manzana.configuracion.aleatorioLongitud.y);
            }
            EditorGUILayout.EndHorizontal();

        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical(style);

        EditorGUILayout.BeginHorizontal();
        
        indiceSeleccionArea = EditorGUILayout.Popup(indiceSeleccionArea, manzana.configuracion.nombreAreas);
        if (GUILayout.Button("Actualizar"))
        {
            seleccionArea._Update();
        }
        if (GUILayout.Button("Seleccionar"))
        {
            Selection.activeObject = seleccionArea.gameObject;

        }
        EditorGUILayout.EndHorizontal();
        seleccionArea = manzana.areas[indiceSeleccionArea];
        if (seleccionArea != null)
        {
            EditorGUILayout.LabelField("Area_" + seleccionArea.configuracion.nombre);
            CreateEditor((Area)manzana.areas[indiceSeleccionArea]).OnInspectorGUI();

        }
        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical(style);

        EditorGUILayout.BeginHorizontal();
        indiceSeleccionLote = EditorGUILayout.Popup(indiceSeleccionLote, manzana.areas[indiceSeleccionArea].configuracion.nombresLotes.ToArray());
        if (indiceSeleccionLote >= seleccionArea.configuracion.lotes.Count)
        {
            indiceSeleccionLote = seleccionArea.configuracion.lotes.Count - 1;
        }

        if (GUILayout.Button("Actualizar"))
        {
            seleccionLote._Update();
        }

        if (GUILayout.Button("Seleccionar"))
        {
                       Selection.activeObject = seleccionLote.gameObject;

        }
        EditorGUILayout.EndHorizontal();
        
        seleccionLote = manzana.areas[indiceSeleccionArea].lotes[indiceSeleccionLote];

        

        if (seleccionLote != null)
        {
            EditorGUILayout.LabelField("Lote_" + seleccionLote.configuracion.nombre);
            CreateEditor((Lote)manzana.areas[indiceSeleccionArea].lotes[indiceSeleccionLote]).OnInspectorGUI();

        }
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();


        EditorUtility.SetDirty(target);
        EditorUtility.SetDirty(((Manzana)target).configuracion);

    }




}
