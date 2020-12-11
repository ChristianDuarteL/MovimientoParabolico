using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    Dictionary<string, string> datosGenerales = new Dictionary<string, string>();
    Dictionary<string, string> datosLB = new Dictionary<string, string>();

    public GameObject datosGeneralesGO;
    public GameObject datosLBGO;
    public static Controlador controlador;

    private void Awake() {
        controlador = this;
        datosGenerales.Add("Angulo", " ");
        datosGenerales.Add("Fuerza", " ");
        datosGenerales.Add("Velocidad inicial", " ");
        datosGenerales.Add("Cursor", " ");
        datosGenerales.Add("Aceleración", " ");
        datosGenerales.Add("Balas en pantalla", " ");
        datosGenerales.Add("Tamaño bala", " ");
        datosGenerales.Add("Intervalo marca", Graficador.intervalo.ToString());
        actualizarDatoGeneral("Aceleración", Fisicas.aceleracion);

        datosLB.Add("Angulo", " ");
        datosLB.Add("Fuerza", " ");
        datosLB.Add("Velocidad inicial", " ");
        datosLB.Add("Velocidad", " ");
        datosLB.Add("Aceleración", " ");
        datosLB.Add("Tiempo desde el lanzamiento", " ");
        datosLB.Add("Tamaño bala", " ");
        datosLB.Add("Chocó", " ");
        actualizarDatoLB("Angulo", " ");
        

    }
    public void actualizarDatoGeneral(string dato, Vector2 v2) {
        actualizarDatoGeneral(dato, "(" + v2.x.ToString() + ", " + v2.y + ")");
    }

    public void actualizarDatoLB(string dato, Vector2 v2) {
        actualizarDatoLB(dato, "(" + v2.x.ToString() + ", " + v2.y + ")");
    }
    public void actualizarDatoLB(string dato, string valor) {
        datosLB[dato] = valor;
        TextMeshProUGUI[] texts = datosLBGO.GetComponentsInChildren<TextMeshProUGUI>();
        int i = 0;
        foreach (KeyValuePair<string, string> item in datosLB) {
            texts[i].text = item.Key + ": " + item.Value;
            i++;
        }
    }
    public void actualizarDatoGeneral(string dato, string valor) {
        datosGenerales[dato] = valor;
        TextMeshProUGUI[] texts = datosGeneralesGO.GetComponentsInChildren<TextMeshProUGUI>();
        int i = 0;
        foreach (KeyValuePair<string, string> item in datosGenerales) {
            texts[i].text = item.Key + ": " + item.Value;
            i++;
        }
    }

}
