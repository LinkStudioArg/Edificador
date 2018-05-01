using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : ScriptableObject {
    [HideInInspector] public string nombre;
    public enum Tipo { BASICO, TIPO1, TIPO2 };
    public Tipo tipo;
    public bool rotate;    
    public float retiroFrente;
    public Vector2 retiroFrenteAleatorio;
    public float retiroFondo;
    public Vector2 retiroFondoAleatorio;
    public float altura = 6;
    public Vector2 alturaAleatorio;
    public float profundidad = 0.5f;
    public Vector2 aleatorioProfundidad;
    public float longitud = 1;
    public Vector2 aleatorioLongitud;
    public bool alturaRPT = false;
    public bool retiroFrenteRPT = false;
    public bool retiroFondoRPT = false;
    public bool excluir;

}
