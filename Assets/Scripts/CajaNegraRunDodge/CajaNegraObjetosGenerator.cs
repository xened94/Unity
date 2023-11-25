using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using pruebasobj;

[TestFixture]
public class CajaNegraObjetosGenerator
{
    [Test]
    public void ObjetosGenerator_CorrectNumberOfObjects()
    {
        // Arrange
        var objetosGeneratorObject = new GameObject();
        var objetosGenerator = objetosGeneratorObject.AddComponent<ObjetosGenerator>();

        // Act
        int actualNumberOfObjects = objetosGenerator.numberOfObjetos;

        // Debug
        Debug.Log("Actual Number of Objects: " + actualNumberOfObjects);

        // Assert
        Assert.AreEqual(10, actualNumberOfObjects, "El número de objetos generados no es el esperado.");
    }

    [Test]
    public void ObjetosGenerator_ValidSpawnRange()
    {
        // Arrange
        var objetosGeneratorObject = new GameObject();
        var objetosGenerator = objetosGeneratorObject.AddComponent<ObjetosGenerator>();

        // Act
        float actualMinX = objetosGenerator.minX;
        float actualMaxX = objetosGenerator.maxX;

        // Debug
        Debug.Log("Actual MinX: " + actualMinX);
        Debug.Log("Actual MaxX: " + actualMaxX);

        // Assert
        Assert.LessOrEqual(actualMinX, actualMaxX, "minX debe ser menor o igual a maxX.");
    }
}
