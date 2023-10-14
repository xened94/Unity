    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float velocidadEnEjeY = 30.0f; // Velocidad de rotación en el eje Y en grados por segundo (configurable en el Inspector).

    void Update()
    {
        // Rota el GameObject en el eje Y a la velocidad dada.
        transform.Rotate(Vector3.up * velocidadEnEjeY * Time.deltaTime);
    }
}