using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjetosGeneratorRampa : MonoBehaviour
{
    public GameObject manzanaRPrefab;
    public GameObject papaRPrefab;
    public GameObject naranjaRPrefab;
    public int numberOfObjetos = 100;

    [SerializeField]
    private float minX = 15f;

    [SerializeField]
    private float maxX = 300f;

    [SerializeField]
    private float minY = 0f;

    [SerializeField]
    private float maxYIncrement = -2f; // Ajuste incremental de maxY

    [SerializeField]
    private float minZ = -5f;

    [SerializeField]
    private float maxZ = 5f;

    void Start()
    {
        GenerateObjects();
    }

    void GenerateObjects()
    {
        List<GameObject> objetos = new List<GameObject> { manzanaRPrefab, papaRPrefab, naranjaRPrefab };
        HashSet<Vector3> usedPositions = new HashSet<Vector3>();

        for (int i = 0; i < numberOfObjetos; i++)
        {
            int randomIndex = Random.Range(0, objetos.Count);
            GameObject objetoPrefab = objetos[randomIndex];

            if (objetoPrefab != null)
            {
                Vector3 spawnPosition = GetUniquePosition(usedPositions);

                // Transforma la posición local a posición del mundo
                spawnPosition = transform.TransformPoint(spawnPosition);

                GameObject newObject = Instantiate(objetoPrefab, spawnPosition, Quaternion.identity);
                newObject.AddComponent<ReiniciarObjeto>();
            }
        }
    }

    Vector3 GetUniquePosition(HashSet<Vector3> usedPositions)
    {
        Vector3 spawnPosition;
        do
        {
            float x = Random.Range(minX, maxX);
            float y = CalculateY(x);
            float z = Random.Range(minZ, maxZ);
            spawnPosition = new Vector3(x, y, z);
        } while (usedPositions.Contains(spawnPosition));

        usedPositions.Add(spawnPosition);
        return spawnPosition;
    }

    float CalculateY(float x)
    {
        // Ajuste la relación entre X e Y según tu nueva descripción
        float result = minY;
        while (x > minX)
        {
            result += maxYIncrement;
            x -= 5f; // Ajusta el valor según tu relación específica
        }

        return result;
    }
}
