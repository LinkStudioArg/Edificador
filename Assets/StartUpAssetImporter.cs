using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class StartUpAssetImporter {
    public static string path;
    //[MenuItem("Menu/")]

    public static List<string> getFilesNames()
    {
        DirectoryInfo d = new DirectoryInfo(path);//@"C:/Users/hunve/AppData/Roaming/Unity/Asset Store-5.x/StartUp");
        FileInfo[] Files = d.GetFiles("*.unitypackage", SearchOption.AllDirectories);
        List<string> files = new List<string>();
        foreach (FileInfo info in Files)
        {
            files.Add(info.Name);
        }
        return files;

    }


    [MenuItem("Packages/Move StartUp Assets", false, 23)]

    static void Move()
    {
        string[] assets = Directory.GetDirectories(Application.dataPath);
        foreach (string dir in assets)
        {
            DirectoryInfo d = new DirectoryInfo(dir);
            string source = @Application.dataPath + "/" + d.Name;
            string destination = @Application.dataPath + "/StartUpAssets/" + d.Name;
            if (Directory.Exists(source))
            {
                if (!Directory.Exists(@Application.dataPath + "/StartUpAssets"))
                    Directory.CreateDirectory(@Application.dataPath + "/StartUpAssets");
                Directory.Move(dir, destination);

            }
        }
        
    }
}
