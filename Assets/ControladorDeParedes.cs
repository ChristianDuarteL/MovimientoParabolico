using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeParedes : MonoBehaviour
{
    public static List<Piso> pisos = new List<Piso>();

    public static bool choco(Vector2 posicionAnterior, Vector2 posicion, float rango) {
        foreach(Piso piso in pisos) {
            if (piso.choco(posicionAnterior, posicion, rango)) {
                return true;
            }
        }
        return false;
    }
}
