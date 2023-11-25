using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using pruebasobj;

[TestFixture]
public class CajaBlancaObjetosGenerator
{
    [UnityTest]
    public IEnumerator SpawnObjectsWithDelay_CorrectObjectsSpawned()
    {
        // Arrange
        var objetosGeneratorObject = new GameObject();
        var objetosGenerator = objetosGeneratorObject.AddComponent<ObjetosGenerator>();

        // Act
        yield return null; // Espera un frame para que Awake se ejecute automáticamente
        yield return null; // Espera otro frame para que Start se ejecute automáticamente

        float elapsedTime = 10f;
        float waitTime = 10f; // Ajusta según sea necesario

        while (elapsedTime < waitTime)
        {
            elapsedTime += Time.deltaTime;
            yield return null; // Espera un frame
        }

        // Accede al resultado después de que se ha ejecutado la lógica de SpawnObjectsWithDelay
        int spawnedObjectsCount = objetosGenerator.gameObject.transform.childCount;

        // Debug
        Debug.Log("Spawned Objects Count: " + spawnedObjectsCount);

        // Assert
        Assert.AreEqual(objetosGenerator.generatedObjectsCount, spawnedObjectsCount, "La cantidad de objetos generados no es la esperada.");
    }

   [UnityTest]
public IEnumerator SpawnObjectsWithDelay_CorrectSpawnPositions()
{
    // Arrange
    var objetosGeneratorObject = new GameObject();
    var objetosGenerator = objetosGeneratorObject.AddComponent<ObjetosGenerator>();

    // Act
    yield return null; // Espera un frame para que Awake y Start se ejecuten automáticamente

    // Accede al resultado después de que se ha ejecutado la lógica de SpawnObjectsWithDelay
    Transform[] spawnedObjects = objetosGenerator.gameObject.GetComponentsInChildren<Transform>();

    // Debug
    Debug.Log("Debugging Spawned Objects Positions");

    // Assert
    foreach (Transform objTransform in spawnedObjects)
    {
        if (objTransform != objetosGeneratorObject.transform)
        {
            float xPosition = objTransform.position.x;

            // Debug
            Debug.Log("Object Position X: " + xPosition + " (Script Purpose: Checking Spawn Positions)");

            Assert.GreaterOrEqual(xPosition, objetosGenerator.minX, "La posición X del objeto generado está fuera del rango mínimo.");
            Assert.LessOrEqual(xPosition, objetosGenerator.maxX, "La posición X del objeto generado está fuera del rango máximo.");
        }
    }
}
        
    
}
