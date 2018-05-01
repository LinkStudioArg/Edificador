using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class Area : MonoBehaviour {
    [SerializeField]public Config_Area configuracion;
    public Manzana manzana;
    public Lote[] lotes;
    public Color color;
    public void _Update()
    {
        foreach (Lote lote in lotes)
        {
            
            if (lote.configuracion.excluir == false)
            {
                lote.configuracion.tipo = configuracion.tipo;
                lote.configuracion.profundidad = configuracion.profundidad;
                lote.configuracion.longitud = configuracion.longitud;
                lote.configuracion.altura = configuracion.altura;
                lote.configuracion.retiroFrente = configuracion.retiroFrente;
                lote.configuracion.retiroFondo = configuracion.retiroFondo;
                lote.configuracion.rotate = configuracion.rotate;
                if (configuracion.alturaRPT)
                    lote.configuracion.altura = Random.Range(configuracion.alturaAleatorio.x, configuracion.alturaAleatorio.y);                
                if(configuracion.retiroFrenteRPT)
                    lote.configuracion.retiroFrente = Random.Range(configuracion.retiroFrenteAleatorio.x, configuracion.retiroFrenteAleatorio.y);
                if(configuracion.retiroFondoRPT)
                    lote.configuracion.retiroFondo = Random.Range(configuracion.retiroFondoAleatorio.x, configuracion.retiroFondoAleatorio.y);
            }
            lote._Update();

        }
    }

    public void Init(Manzana manzana, int numero)
    {
        this.manzana = manzana;

        Config_Area aux = ScriptableObject.CreateInstance<Config_Area>();
        aux.nombre = manzana.configuracion.nombre + "_" + numero.ToString();
        CreateAssetInFolder(aux, "Configs/Manzanas/Manzana_"+manzana.configuracion.nombre+"/Area_"+aux.nombre, "Area_" + aux.nombre);

        //AssetDatabase.CreateAsset(aux, "Assets/Edificador/Configs/Areas/Area_" + aux.nombre + ".asset");
        AssetDatabase.SaveAssets();
        configuracion = aux;
        configuracion.area = GetComponent<Area>();

        manzana.configuracion.areas[numero] = configuracion;
        for (int i = 0; i < lotes.Length; i++)
        {
            lotes[i].Init(this, i);
            configuracion.nombresLotes.Add("Lote_" + manzana.configuracion.nombre + "_" +i);

        }
    }


    public void CreateAssetInFolder(Object newAsset, string ParentFolder, string AssetName)
    {
        System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(string.Format("{0}/{1}", Application.dataPath, ParentFolder));
        dirInfo.Create();

        AssetDatabase.CreateAsset(newAsset, string.Format("Assets/{0}/{1}.asset", ParentFolder, AssetName));
    }

}
