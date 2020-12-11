using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graficador : MonoBehaviour
{
    public GameObject prefab;
    public GameObject salida;
    public Disparador disparador;
    public float tiempo;
    public static float intervalo = .25f;

    public void mostrarGrafica() {
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        for (float t = 0; t < tiempo; t += intervalo) {
            addSombra(t);
        }
    }

    public void addSombra(float time) {
        Vector3 pos = salida.transform.position + (Vector3)Fisicas.calcularPosicion(disparador.velocidad, Fisicas.aceleracion, time);
        GameObject go = Instantiate(prefab, transform);
        go.transform.position = pos;
    }

}
