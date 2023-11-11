using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limonquecae : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de caída
    public float tiempoEspera = 2.0f; // Tiempo de espera antes de que aparezca el siguiente objeto

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
        StartCoroutine(SpawnObjectWithDelay());
    }

    IEnumerator SpawnObjectWithDelay()
    {
        while (true)
        {
            // Espera el tiempo especificado
            yield return new WaitForSeconds(tiempoEspera);

            // Restablece la posición
            transform.position = posicionInicial;

            // Activa el objeto
            gameObject.SetActive(true);

            // Reinicia su movimiento
            // (en este ejemplo, solo reiniciamos su posición)
        }
    }

    void Update()
    {
        // Mueve el objeto hacia abajo a lo largo del eje Y
        transform.Translate(Vector3.down * velocidad * Time.deltaTime);

        // Si el objeto cae fuera de la pantalla, desactívalo
        if (transform.position.y < -5f)
        {
            gameObject.SetActive(true);
        }
    }
}