using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObScript : MonoBehaviour
{
    public int valorPuntaje = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Agregar el puntaje al recolector de puntaje.
            Recolectar recolector = FindObjectOfType<Recolectar>();
            recolector.SumarPuntaje(valorPuntaje);

            // Opcional: Realizar efectos o destruir el objeto obstáculo.
            Destroy(gameObject);
        }
    }
}