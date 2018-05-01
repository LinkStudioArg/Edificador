using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Edificador))]
public class EdificadorInspector : Editor {
    Edificador edificador;
    public override void OnInspectorGUI()
    {
        Edificador edificador = target as Edificador;

        if (GUILayout.Button("Crear Manzana"))
        {
            edificador.CrearManzana(edificador.manzanas.Count + 1);
        }
        foreach (var manzana in edificador.manzanas)
        {
            CreateEditor(manzana.configuracion).OnInspectorGUI();              
        }
        // DrawDefaultInspector();
        EditorUtility.SetDirty(target);

    }

}
