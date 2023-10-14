using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recolectar : MonoBehaviour
{
    private int puntajeTotal = 0;
    public Text puntajeText; // Texto en pantalla para mostrar el puntaje.
    public Text mensajeFinal; // Texto en pantalla para mostrar el mensaje final.

    public void SumarPuntaje(int puntaje)
    {
        puntajeTotal += puntaje;
        ActualizarPuntajeEnPantalla();
    }

    void ActualizarPuntajeEnPantalla()
    {
        puntajeText.text = "Puntaje: " + puntajeTotal;
    }

    // Llamar a esta función al final del juego para mostrar el mensaje final.
    public void MostrarMensajeFinal()
    {
        mensajeFinal.text = "¡Felicidades! Obtuviste " + puntajeTotal + " puntos. ";
    }
}