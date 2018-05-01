using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Config_Area : Config {
    
    [HideInInspector] public List<Config_Lote> lotes = new List<Config_Lote>();
    [HideInInspector] public List<string> nombresLotes = new List<string>();
    [HideInInspector] public Area area;

    public void Init(Vector2 dimension, float retiroFE, float retiroFO, float altura)
    {
        this.retiroFrente = retiroFE;
        this.retiroFondo = retiroFO;
        this.altura = altura;
        this.lotes = new List<Config_Lote>();
    }
}
