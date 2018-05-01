using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Config_Manzana : Config {
       
    public float centroManzana;
    //public float vereda;
    //public float retiro;
    [HideInInspector] public Config_Area[] areas = new Config_Area[7];
    [HideInInspector] public string[] nombreAreas = new string[7];
    [HideInInspector] public Manzana manzana;


    public void Init(Area[] areas)
    {
        centroManzana = 35;
    }

}
