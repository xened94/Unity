using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OntriggerCollider : MonoBehaviour
{
   
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
            
            Debug.Log("Contacto");
            audioPlayer.Play();

            // Reproduce el sonido de recolección
            
            

            // Llama a la función MostrarMensajeFinal del script Recolectar.
            recolectarScript.MostrarMensajeFinal();
             
            // Reproduce el sonido del mensaje final
           // Accede a la instancia actual de GameManager y establece el nombre del minijuego
            GameManager gameManagerInstance = FindObjectOfType<GameManager>();
            if (gameManagerInstance != null)
            {
                gameManagerInstance.SetNombreMinijuego(GetNombreEscena());
            }
            else
            {
                Debug.LogError("No se encontró una instancia de GameManager.");
            }


            // Pausa el juego
            GameManager.CambiarEstadoJuego();
           GameManager.FinalizarJuegoStatic();
           
        }
    }
        // Obtiene el nombre de la escena actual
    private string GetNombreEscena()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}