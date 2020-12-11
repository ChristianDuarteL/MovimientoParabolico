using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject bala;
    public float multiplicadorFuerza;
    public float fuerzaMaxima;
    public float sizeBala;

    float fuerza;
    public Vector2 velocidad;

    Camera c;
    private void Start() {
        c = Camera.main;
        Controlador.controlador.actualizarDatoGeneral("Tamaño bala", sizeBala.ToString());
        Controlador.controlador.actualizarDatoGeneral("Balas en pantalla", 0.ToString());
    }

    private void Update() {
        Vector2 mp = Input.mousePosition;
        Vector3 worldPoint = c.ScreenToWorldPoint(mp);
        worldPoint.z = 0;
        fuerza = obtenerFuerza(worldPoint);
        velocidad = obtenerVelocidadInicial(fuerza);
        Controlador.controlador.actualizarDatoGeneral("Fuerza", fuerza.ToString());
        Controlador.controlador.actualizarDatoGeneral("Velocidad inicial", velocidad);
        Controlador.controlador.actualizarDatoGeneral("Cursor", (Vector2)mp);
        if (Input.GetMouseButtonDown(0)) {
            Disparar(velocidad);
        }
    }

    public float obtenerFuerza(Vector3 pos) {
        return Mathf.Clamp(((Vector2)pos - (Vector2)transform.position).magnitude * multiplicadorFuerza, 0 , fuerzaMaxima);
    }

    public Vector2 obtenerVelocidadInicial(float fuerza) {
        return new Vector2(Mathf.Cos(RotacionCañon.angle * Mathf.Deg2Rad) * fuerza, Mathf.Sin(RotacionCañon.angle * Mathf.Deg2Rad) * fuerza);
    }

    public void Disparar(Vector2 velocidad) {
        GameObject balaInstanciada = Instantiate(bala);
        Proyectil b = balaInstanciada.GetComponent<Proyectil>();
        b.velocidadLanzada = velocidad;
        b.transform.position = transform.position;
        b.Lanzar(sizeBala, fuerza, velocidad, RotacionCañon.angle);
    }
}
