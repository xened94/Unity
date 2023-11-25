using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace recolectarpruebas
{
    public class Recolectar : MonoBehaviour
    {
        public int puntajeTotal = 0;
        public IPuntajeText puntajeText;  // Cambiado a interfaz
        public IMensajeFinalFondo mensajeFinalFondo;  // Cambiado a interfaz
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
            PuntajeEnPantalla();
        }

        void PuntajeEnPantalla()
        {
            puntajeText.SetText("Puntaje: " + puntajeTotal);
        }

        // Llamar a esta función al final del juego para mostrar el mensaje final.
        public void MostrarMensajeFinal()
        {
            // Obtén el nombre del jugador desde PlayerPrefs
            string nombre = PlayerPrefs.GetString("NombreJugador");

            // Resto del código...

            mensajeFinalFondo.SetActive(true);
            mensajeFinalFondo.SetMensaje("¡Felicidades, " + nombre + "! Obtuviste " + puntajeTotal + " puntos. ");
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

    public interface IPuntajeText
    {
        void SetText(string text);
    }

    public interface IMensajeFinalFondo
    {
        void SetActive(bool active);
        void SetMensaje(string mensaje);
    }

    public class MockPuntajeText : IPuntajeText
    {
        public string LastSetText { get; private set; }

        public void SetText(string text)
        {
            LastSetText = text;
        }
    }

    public class MockMensajeFinalFondo : IMensajeFinalFondo
    {
        public bool LastSetActive { get; private set; }
        public string LastSetMensaje { get; private set; }

        public void SetActive(bool active)
        {
            LastSetActive = active;
        }

        public void SetMensaje(string mensaje)
        {
            LastSetMensaje = mensaje;
        }
    }
}
