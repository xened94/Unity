using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OntriggerCollider : MonoBehaviour
{
    public GameObject UIObject;
    public Recolectar recolectarScript; // Variable para la referencia al script Recolectar

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.juegoPausado)
        {
            // Si el juego está pausado, reanúdalo
            GameManager.CambiarEstadoJuego();
        }
        else
        {
            // Si el juego no está pausado, haz la pausa
             UIObject.SetActive(true);
            Debug.Log("Contacto");

            // Llama a la función MostrarMensajeFinal del script Recolectar.
            recolectarScript.MostrarMensajeFinal();

            // Pausa el juego
            GameManager.CambiarEstadoJuego();
        }
    }
}