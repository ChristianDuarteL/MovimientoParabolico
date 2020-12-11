using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fisicas : MonoBehaviour
{
    public static Vector2 aceleracion = new Vector2(0, -9.81f);

    public static Vector2 calcularVelocidadInicial(float angle, float force) {
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
    }

    public static Vector2 calcularPosicion(Vector2 velocidadInicial, Vector2 aceleracion, float tiempo) {
        float tiempoCuadrado = tiempo * tiempo * .5f;
        return new Vector2(velocidadInicial.x * tiempo + tiempoCuadrado * aceleracion.x, velocidadInicial.y * tiempo + tiempoCuadrado * aceleracion.y);
    }
}
