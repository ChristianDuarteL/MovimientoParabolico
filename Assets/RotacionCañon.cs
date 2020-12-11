using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCañon : MonoBehaviour
{
    public Transform canonCenter;
    public float range;
    public float centerAngle;

    public static float angle;

    public Graficador graficador;
    Camera c;
    private void Start() {
        c = Camera.main;
    }
    private void Update() {
        Vector2 mp = Input.mousePosition;
        Vector3 worldPoint = c.ScreenToWorldPoint(mp);
        Vector2 vectorResultante = canonCenter.transform.position - worldPoint;

        float lastAngle = Mathf.Atan2(vectorResultante.y, vectorResultante.x) * Mathf.Rad2Deg + 180;

        if(centerAngle - range / 2 < 0) {
            if (lastAngle > centerAngle + range / 2 && lastAngle < 360 + (centerAngle - range / 2) % 360) {
                if(Mathf.Abs(lastAngle - centerAngle + range / 2) < Mathf.Abs(lastAngle - 360 + (centerAngle - range / 2) % 360)) {
                    lastAngle = centerAngle + range / 2;
                }
                else {
                    lastAngle = 360 + (centerAngle - range / 2) % 360;
                }
                
            }
        }

        if(lastAngle != angle) {
            angle = lastAngle;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            Controlador.controlador.actualizarDatoGeneral("Angulo", angle.ToString());
            graficador.mostrarGrafica();
        }
    }
}
