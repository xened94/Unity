using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObScript : MonoBehaviour
{
    public int valorPuntaje = 10;
    private AudioSource audioPlayer;  // Remueve la referencia pública

    private void Start()
    {
        // Obtener la referencia al AudioSource en tiempo de ejecución
        audioPlayer = GameObject.Find("recolectarAudioSource").GetComponent<AudioSource>();
    }

private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        Recolectar recolector = FindObjectOfType<Recolectar>();
        recolector.SumarPuntaje(valorPuntaje);

        audioPlayer.Play();

        // Llama a la función Reiniciar en lugar de simplemente activar
        GetComponent<ReiniciarObjeto>().Reiniciar();
    }
}
}