using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recolectar : MonoBehaviour
{
    public int puntajeTotal = 0;
    public Text puntajeText; // Texto en pantalla para mostrar el puntaje.
    public Text mensajeFinal; // Texto en pantalla para mostrar el mensaje final.
    

    private void Start()
    {
        // Obtén el nombre del jugador desde PlayerPrefs
        string nombre = PlayerPrefs.GetString("NombreJugador");
        Debug.Log("Nombre del jugador: " + nombre);
    }

    
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
        // Obtén el nombre del jugador desde PlayerPrefs
        string nombre = PlayerPrefs.GetString("NombreJugador");

        // Resto del código para mostrar el mensaje final
        mensajeFinal.text = "¡Felicidades, " + nombre + "! Obtuviste " + puntajeTotal + " puntos. ";
        Time.fixedDeltaTime = 0f;
    }

}