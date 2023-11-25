using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using reiniciarobjeto;
namespace pruebasobj
{
    public class ObjetosGenerator : MonoBehaviour
    {
        public GameObject manzanaPrefab;
        public GameObject naranjaPrefab;
        public GameObject papaPrefab;
        public int numberOfObjetos = 10; // Puedes ajustar este número
        public int generatedObjectsCount = 0; // Nuevo contador
        public float minX = -5f; // Valor mínimo para X
        public float maxX = 5f;  // Valor máximo para X

        void Awake()
        {
            numberOfObjetos = 10; // Establece el valor predeterminado

            StartCoroutine(SpawnObjectsWithDelay());
        }

       
        IEnumerator SpawnObjectsWithDelay()
        {
            List<GameObject> objetos = new List<GameObject> { manzanaPrefab, naranjaPrefab, papaPrefab };

            while (generatedObjectsCount < numberOfObjetos) // Verifica el nuevo contador
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

                        generatedObjectsCount++; // Incrementa el nuevo contador

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
}