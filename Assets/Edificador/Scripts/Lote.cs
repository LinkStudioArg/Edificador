using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[System.Serializable]
public class Lote : MonoBehaviour {

    [SerializeField] public Config_Lote configuracion;
    [SerializeField] public Area area; 
    public Transform myTransform;
    public Vector3 pos;
    public Vector3 escala;
    public void Init(Area area, int numero)
    {
        myTransform = transform;

        this.area = area;
        pos = myTransform.localPosition;
        escala = myTransform.localScale;
        Config_Lote aux = ScriptableObject.CreateInstance<Config_Lote>();
        aux.nombre = area.configuracion.nombre + "_" + numero.ToString();
        //AssetDatabase.CreateAsset(aux, "Assets/Edificador/Configs/Lotes/Lote_" + aux.nombre + ".asset");
        CreateAssetInFolder(aux, "Configs/Manzanas/Manzana_"+area.manzana.configuracion.nombre+"/Area_"+area.configuracion.nombre+"/Lote_"+aux.nombre, "Lote_" + aux.nombre);

        AssetDatabase.SaveAssets();
        configuracion = aux;
        area.configuracion.lotes.Add(configuracion);
        ((modifyEdgeLoop)GetComponentInChildren(typeof(modifyEdgeLoop), true)).parentTransform = null;
        ((modifyEdgeLoop)GetComponentInChildren(typeof(modifyEdgeLoop), true)).Init() ;

    }


    public void CreateAssetInFolder(Object newAsset, string ParentFolder, string AssetName)
    {
        System.IO.DirectoryInfo dirInfo = new System.IO.DirectoryInfo(string.Format("{0}/{1}", Application.dataPath, ParentFolder));
        dirInfo.Create();

        AssetDatabase.CreateAsset(newAsset, string.Format("Assets/{0}/{1}.asset", ParentFolder, AssetName));
    }

    public void DisableChildren()
    {
        for (int i = 0; i < myTransform.childCount; i++)
        {
            myTransform.GetChild(i).GetComponentInChildren<Renderer>().enabled = false;
        }
    }

    public void _Update()
    {
        if (myTransform == null)
            myTransform = transform;

        //Reseteo, si es tipo 1, se reseteo el hueco;
        DisableChildren();
        if (configuracion.tipo == Config_Lote.Tipo.TIPO1)
        {
            myTransform.GetChild(1).GetComponentInChildren<Renderer>().enabled = true;
            ((modifyEdgeLoop)GetComponentInChildren(typeof(modifyEdgeLoop), true)).Reset();
        }
        else if (configuracion.tipo == Config_Lote.Tipo.BASICO)
        {
            myTransform.GetChild(0).GetComponentInChildren<Renderer>().enabled = true;
        }

        //Reseteo, se resetea la escala del lote.
        Vector3 newScale = escala;
        Vector3 newPos = pos;

        myTransform.localPosition = newPos;
        myTransform.localScale = newScale;

        //Rotar
        if (configuracion.rotate && configuracion.tipo == Config_Lote.Tipo.TIPO1)
            myTransform.GetChild(1).localRotation = Quaternion.Euler(0, 180, 0);
        else
            myTransform.GetChild(1).localRotation = Quaternion.Euler(0, 0, 0);


        //Actualizacion, se redimensiona el objeto segun la configuracion

        float centro = area.manzana.configuracion.centroManzana;
        if (Mathf.Abs(pos.x) - escala.x / 2 < centro / 2 && Mathf.Abs(pos.z) - escala.z / 2 < centro / 2)//centro de manzana
        {
            newScale.x = escala.x / 2 - centro / 2 + Mathf.Abs(pos.x);

            if (pos.x != 0f)
                newPos.x = (pos.x / Mathf.Abs(pos.x)) * (Mathf.Abs(pos.x) / 2 + centro / 4 + escala.x / 4); 
            else
                newPos.x = (Mathf.Abs(pos.x) / 2 + centro / 4 + escala.x / 4);

            if (newScale.x > escala.x)
            {
                newScale.x = escala.x;
                newPos.x = pos.x;
            }
        }

        //Actualizacion, se aplican los retiros
        float retiro_total = configuracion.retiroFrente + configuracion.retiroFondo;
        newScale.x -= retiro_total;
        if(pos.x!=0f)
            newPos.x += (pos.x / Mathf.Abs(pos.x))*(configuracion.retiroFondo - configuracion.retiroFrente) /2;
        else
            newPos.x+= (configuracion.retiroFondo - configuracion.retiroFrente) / 2;
        newScale.y = configuracion.altura;

        myTransform.localPosition = newPos;
        myTransform.localScale = newScale;

        //Actualizacion, se mueven los loops para formar el nuevo hueco

        if (configuracion.tipo == Config_Lote.Tipo.TIPO1)
        {
            ((modifyEdgeLoop)GetComponentInChildren(typeof(modifyEdgeLoop), true)).SetValues(configuracion.profundidad, configuracion.longitud);

            ((modifyEdgeLoop)GetComponentInChildren(typeof(modifyEdgeLoop), true))._UpdateCarve();
        }
    }
    

}
