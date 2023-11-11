using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetosGenerator : MonoBehaviour
{
    public GameObject manzanaPrefab;
    public GameObject naranjaPrefab;
    public GameObject papaPrefab;
    public int numberOfObjetos = 10; // Puedes ajustar este número
    public float minX = -5f; // Valor mínimo para X
    public float maxX = 5f;  // Valor máximo para X

    void Start()
    {
        StartCoroutine(SpawnObjectsWithDelay());
    }

    IEnumerator SpawnObjectsWithDelay()
    {
        List<GameObject> objetos = new List<GameObject> { manzanaPrefab, naranjaPrefab, papaPrefab };

        while (true)
        {
            if (objetos.Count > 0)
            {
                int randomIndex = Random.Range(0, objetos.Count);
                GameObject objetoPrefab = objetos[randomIndex];

                if (objetoPrefab != null)
                {
                    float x = Random.Range(minX, maxX);
                    float y = 5.0f;
                    float z = 0f;
                    Vector3 spawnPosition = new Vector3(x, y, z);

                    // Duración predeterminada (5 segundos)
                    float tiempoDeEspera = 5.0f;

                    GameObject newObject = Instantiate(objetoPrefab, spawnPosition, Quaternion.identity);
                    newObject.AddComponent<ReiniciarObjeto>();

                    objetos.RemoveAt(randomIndex);

                    yield return new WaitForSeconds(tiempoDeEspera);
                }
            }
            else
            {
                objetos.AddRange(new[] { manzanaPrefab, naranjaPrefab, papaPrefab });
            }
        }
    }
}