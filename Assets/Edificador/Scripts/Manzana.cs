using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class Manzana : MonoBehaviour {

    [SerializeField] public Config_Manzana configuracion;

    [SerializeField] public Area[] areas = new Area[7];

    [SerializeField] public int indice;

    public void _Update()
    {
        foreach (Area area in areas)
        {
            if (area.configuracion.excluir == false)
            {
                area.configuracion.tipo = configuracion.tipo;
                area.configuracion.profundidad = configuracion.profundidad;
                area.configuracion.longitud = configuracion.longitud;
                area.configuracion.altura = configuracion.altura;
                area.configuracion.retiroFrente = configuracion.retiroFrente;
                area.configuracion.retiroFondo = configuracion.retiroFondo;
                area.configuracion.rotate = configuracion.rotate;

                area.configuracion.retiroFondoAleatorio = configuracion.retiroFondoAleatorio;
                area.configuracion.retiroFrenteAleatorio = configuracion.retiroFrenteAleatorio;
                area.configuracion.alturaAleatorio = configuracion.alturaAleatorio;
                area.configuracion.alturaRPT = configuracion.alturaRPT;
                area.configuracion.retiroFondoRPT = configuracion.retiroFondoRPT;
                area.configuracion.retiroFrenteRPT = configuracion.retiroFrenteRPT;

                if (configuracion.alturaRPT)
                    area.configuracion.altura = Random.Range(configuracion.alturaAleatorio.x, configuracion.alturaAleatorio.y);
                if (configuracion.retiroFrenteRPT)
                    area.configuracion.retiroFrente = Random.Range(configuracion.retiroFrenteAleatorio.x, configuracion.retiroFrenteAleatorio.y);
                if (configuracion.retiroFondoRPT)
                    area.configuracion.retiroFondo = Random.Range(configuracion.retiroFondoAleatorio.x, configuracion.retiroFondoAleatorio.y);

                area._Update();

            }

        }
    }

    public void Init(int numero)
    {
        indice = numero;
        Config_Manzana manzana =  ScriptableObject.CreateInstance<Config_Manzana>();
        manzana.nombre = numero.ToString();
        CreateAssetInFolder(manzana, "Configs/Manzanas/Manzana_"+ manzana.nombre, "Manzana_" + manzana.nombre);

        //AssetDatabase.CreateAsset(manzana, "Assets/Edificador/Configs/Manzanas/Manzana_" + manzana.nombre + ".asset");
        AssetDatabase.SaveAssets();
        configuracion = manzana;
        configuracion.manzana = GetComponent<Manzana>();

        Area[] children = GetComponentsInChildren<Area>();

        for (int i = 0; i < 7; i++)
        {
            areas[i] = children[i];
            areas[i].Init(this, i);
            configuracion.nombreAreas[i] = "Area_" + configuracion.nombre + "_" + i;

        }
    }

    public void CreateAssetInFolder(Object newAsset, string ParentFolder, string AssetName)
    {
        System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(string.Format("{0}/{1}", Application.dataPath, ParentFolder));
        dirInfo.Create();

        AssetDatabase.CreateAsset(newAsset, string.Format("Assets/{0}/{1}.asset", ParentFolder, AssetName));
    }
}
