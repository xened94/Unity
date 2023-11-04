using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OntriggerCollider : MonoBehaviour
{
    public GameObject UIObject;
    public Recolectar recolectarScript;
    public AudioSource audioPlayer;

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
            audioPlayer.Play();

            // Reproduce el sonido de recolección
            
            

            // Llama a la función MostrarMensajeFinal del script Recolectar.
            recolectarScript.MostrarMensajeFinal();

            // Reproduce el sonido del mensaje final
            

            // Pausa el juego
            GameManager.CambiarEstadoJuego();
        }
    }
}



