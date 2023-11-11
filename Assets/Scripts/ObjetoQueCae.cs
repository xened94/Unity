
using System.Collections;
using UnityEngine;

public class ObjetoQueCae : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de caída
    public float tiempoEspera = 2.0f; // Tiempo de espera antes de que aparezca el siguiente objeto
    public float minX = -5f; // Valor mínimo para X
    public float maxX = 5f;  // Valor máximo para X

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = GetRandomSpawnPosition();
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
            StartCoroutine(MoveObjectDown());
        }
    }

    IEnumerator MoveObjectDown()
    {
        while (transform.position.y > -5f)
        {
            // Mueve el objeto hacia abajo a lo largo del eje Y
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
            yield return null;
        }

        // Desactiva el objeto cuando alcanza una cierta posición en Y
        gameObject.SetActive(false);
    }

    Vector3 GetRandomSpawnPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = 5.0f; // Altura fija en Y
        float z = 0f; // Posición Z fija en 0
        return new Vector3(x, y, z);
    }
}
