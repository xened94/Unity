using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recolectar : MonoBehaviour
{
    public string nombre = "";
    public ControlDeNombre controlDeNombre;
    public int puntajeTotal = 0;
    public Text puntajeText; // Texto en pantalla para mostrar el puntaje.
    public Text mensajeFinal; // Texto en pantalla para mostrar el mensaje final.
    public GameObject elementosUI;

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
    mensajeFinal.text = "¡Felicidades, " + nombre + "! Obtuviste " + puntajeTotal + " puntos. ";
    elementosUI.SetActive(!GameManager.juegoPausado);
}

public void SetNombre(string nuevoNombre)
{
    nombre = nuevoNombre;
}
}