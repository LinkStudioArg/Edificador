using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
public class StarUpAssetImporterEditor :  EditorWindow{

        private static string path;
    [MenuItem("Assets/Import Package/From Folder")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        StarUpAssetImporterEditor window = (StarUpAssetImporterEditor)EditorWindow.GetWindow(typeof(StarUpAssetImporterEditor));
        window.Show();
    }
    public class fileNameCheck
    {
        public string name;
        public bool import;
        public string fullname;
        public fileNameCheck( string name, string fullname, bool import )
        {
            this.name = name;
            this.fullname = fullname;
            this.import = import;
        }
    }
    bool all = false;
    bool none = false;
   public  List<fileNameCheck> filesNamesChecks;
    Vector2 scroll;
    private void OnGUI()
    {
        if (GUILayout.Button("Select Folder"))
        {
            filesNamesChecks = new List<fileNameCheck>();
            path = EditorUtility.OpenFolderPanel("Import From Folder", "", "");
             List<FileInfo> filesNames = getFilesNames();
                        
            foreach (FileInfo s in filesNames)
            {
                filesNamesChecks.Add(new fileNameCheck(s.Name, s.FullName,  true));
            }
        }
        if (filesNamesChecks != null)
        {
            
            if (GUILayout.Button("All"))
            {
                all = true;
            }
            else if (GUILayout.Button("None"))
            {
                none = true;
            }
            scroll = EditorGUILayout.BeginScrollView(scroll);
            for (int i =0; i< filesNamesChecks.Count; i++)
            {
                filesNamesChecks[i].import = EditorGUILayout.ToggleLeft(filesNamesChecks[i].name, filesNamesChecks[i].import);
                if (all)
                    filesNamesChecks[i].import = true;
                if (none)
                    filesNamesChecks[i].import = false;
            }
            EditorGUILayout.EndScrollView();
            all = false;
            none = false;
            if (GUILayout.Button("Import"))
            {
                Import();
            }
        }

       
    }

    public static List<FileInfo> getFilesNames()
    {
        DirectoryInfo d = new DirectoryInfo(path);//@"C:/Users/hunve/AppData/Roaming/Unity/Asset Store-5.x/StartUp");
        FileInfo[] Files = d.GetFiles("*.unitypackage", SearchOption.AllDirectories);
        List<FileInfo> files = new List<FileInfo>();
        foreach (FileInfo info in Files)
        {

            files.Add(info);
        }
        return files;

    }

    static List<string> Files;
    public  void Import()
    {
        foreach (var s in filesNamesChecks)
        {

            if (s.import)
            {
                Debug.Log(s.fullname);
                AssetDatabase.ImportPackage(s.fullname, false);
            }
        }
    }

}
