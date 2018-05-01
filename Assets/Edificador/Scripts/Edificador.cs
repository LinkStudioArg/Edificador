using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Edificador:MonoBehaviour {

    [SerializeField] public List<Manzana> manzanas = new List<Manzana>();

    public void Init()
    {
        manzanas = new List<Manzana>();
    }

    public void CrearManzana(int numero)
    {
        GameObject prefab = (GameObject)Resources.Load("Manzana");

        GameObject nuevaManzana = Instantiate<GameObject>(prefab, this.transform);
        Manzana manzana = nuevaManzana.GetComponent<Manzana>();
        manzana.Init(manzanas.Count+1);
        manzanas.Add(manzana);
    }
    [ContextMenu("Save")]
    public void Save()
    {
    }
    
}
