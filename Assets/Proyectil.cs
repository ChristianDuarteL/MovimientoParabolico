using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public Vector2 velocidadLanzada;
    public float timeElapsed;

    public bool lanzada;
    public bool ended;
    public float diametro;
    public Vector3 startPosition;
    public float tiempoDesaparecer;
    public float animacionDesaparecerDuracion;
    public SpriteRenderer[] sprites;

    public float sizeBala;
    public static int balasEnPantalla = 0;

    public static Proyectil lastBala;

    float angulo;
    float fuerza;
    Vector2 velocidadInicial;
    public Vector2 aceleracion;


    private void Awake() {
        

    }

    private void FixedUpdate() {
        timeElapsed += Time.deltaTime;
        if (lanzada && !ended && timeElapsed < tiempoDesaparecer) {
            if (!ControladorDeParedes.choco(transform.position, startPosition + (Vector3)Fisicas.calcularPosicion(velocidadLanzada, aceleracion, timeElapsed), diametro)) {
                transform.position = startPosition + (Vector3)Fisicas.calcularPosicion(velocidadLanzada, aceleracion, timeElapsed);
            }
            else {
                ended = true;
                Controlador.controlador.actualizarDatoLB("Chocó", "Si");
                Controlador.controlador.actualizarDatoLB("Velocidad", Vector2.zero);
            }
        }
        if(timeElapsed > tiempoDesaparecer) {
            foreach(SpriteRenderer spr in sprites) {
                spr.color = new Color(spr.color.r, spr.color.g, spr.color.b, 1 - (timeElapsed - tiempoDesaparecer) / animacionDesaparecerDuracion);
            }
            if(timeElapsed > tiempoDesaparecer + animacionDesaparecerDuracion) {
                Destroy(gameObject);
                balasEnPantalla--;
                Controlador.controlador.actualizarDatoGeneral("Balas en pantalla", balasEnPantalla.ToString());
            }
        }
        if(this == lastBala) {
            if(!ended)
                Controlador.controlador.actualizarDatoLB("Velocidad", velocidadInicial + aceleracion * timeElapsed);
            Controlador.controlador.actualizarDatoLB("Tiempo desde el lanzamiento", timeElapsed.ToString());
        }
    }

    public void Lanzar(float sizeBala, float fuerza, Vector2 velocidadInicial, float angulo) {
        this.sizeBala = sizeBala;
        startPosition = transform.position;
        lanzada = true;
        balasEnPantalla++;
        aceleracion = Fisicas.aceleracion;
        this.velocidadInicial = velocidadInicial;
        lastBala = this;
        Controlador.controlador.actualizarDatoGeneral("Balas en pantalla", balasEnPantalla.ToString());
        Controlador.controlador.actualizarDatoLB("Angulo", angulo.ToString());
        Controlador.controlador.actualizarDatoLB("Fuerza", fuerza.ToString());
        Controlador.controlador.actualizarDatoLB("Velocidad inicial", velocidadInicial);
        Controlador.controlador.actualizarDatoLB("Aceleración", aceleracion);
        Controlador.controlador.actualizarDatoLB("Tiempo desde el lanzamiento", (0.0f).ToString());
        Controlador.controlador.actualizarDatoLB("Tamaño bala", sizeBala.ToString());
        Controlador.controlador.actualizarDatoLB("Chocó", "No");
    }


}
