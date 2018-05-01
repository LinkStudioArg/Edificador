using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EdificadorWindow : EditorWindow {

    static Edificador edificador;
    [MenuItem("Window/Edificador")]
	public static void ShowWindow()
    {
        edificador = new GameObject("Edificador").AddComponent<Edificador>();
        Selection.activeObject = edificador;
        ActiveEditorTracker.sharedTracker.isLocked = true;
        //edificador.Init();
        //EdificadorWindow window = (EdificadorWindow)EditorWindow.GetWindow(typeof(EdificadorWindow));
        //window.Show();
    }
    




}
