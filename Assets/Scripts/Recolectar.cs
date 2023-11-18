using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recolectar : MonoBehaviour
{
    public int puntajeTotal = 0;
    public GameObject mensajeFinalFondo;
    public Text puntajeText; // Texto en pantalla para mostrar el puntaje.
    public Text mensajeFinal; // Texto en pantalla para mostrar el mensaje final.
    public string nombreJugador;

    private void Start()
    {
        // Obtén el nombre del jugador desde PlayerPrefs
        nombreJugador = PlayerPrefs.GetString("NombreJugador");
        Debug.Log("Nombre del jugador: " + nombreJugador);
    }

    public void SetPlayerName(string name)
    {
        nombreJugador = name;
        PlayerPrefs.SetString("NombreJugador", nombreJugador);
        PlayerPrefs.Save(); // Asegúrate de guardar los cambios en PlayerPrefs
         Debug.Log("Nombre del jugador guardado: " + nombreJugador);
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
        mensajeFinalFondo.SetActive(true);
        mensajeFinal.text = "¡Felicidades, " + nombre + "! Obtuviste " + puntajeTotal + " puntos. ";
        Time.timeScale = 0;
    }

    public int ObtenerPuntajeTotal()
    {
        return puntajeTotal;
    }

    public string ObtenerNombreJugador()
    {
         Debug.Log("Nombre del jugador obtenido: " + nombreJugador);
        return nombreJugador;
    }
}