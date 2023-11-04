using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MensajeFinalController : MonoBehaviour
{
    public GameObject mensajeFinalFondo;
    public Text mensajeFinal;

    private bool mostrarMensaje = false;

    public void MostrarMensajeFinal(string nombreJugador, int puntajeTotal)
    {
        mostrarMensaje = true;

        // Configura el mensaje final con el nombre del jugador y el puntaje.
        mensajeFinal.text = "¡Felicidades, " + nombreJugador + "! Obtuviste " + puntajeTotal + " puntos. ";
    }

    private void Update()
    {
        if (mostrarMensaje)
        {
            mensajeFinalFondo.SetActive(true);
        }
    }
}