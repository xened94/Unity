using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using rampa;

[TestFixture]
public class CajaNegraObjetosGeneratorRampa
{
    [Test]
    public void ObjetosGeneratorRampa_CorrectNumberOfObjects()
    {
        // Arrange
        var objetosGeneratorRampaObject = new GameObject();
        var objetosGeneratorRampa = objetosGeneratorRampaObject.AddComponent<ObjetosGeneratorRampa>();

        // Act
        int actualNumberOfObjects = objetosGeneratorRampa.numberOfObjetos;
        Debug.Log($"Número de objetos generados: {actualNumberOfObjects}");
        // Assert
        Assert.AreEqual(100, actualNumberOfObjects, "El número de objetos generados no es el esperado.");
    }

    [Test]
    public void ObjetosGeneratorRampa_ValidSpawnRange()
    {
        // Arrange
        var objetosGeneratorRampaObject = new GameObject();
        var objetosGeneratorRampa = objetosGeneratorRampaObject.AddComponent<ObjetosGeneratorRampa>();

        // Act
        float actualMinX = objetosGeneratorRampa.minX;
        float actualMaxX = objetosGeneratorRampa.maxX;
        float actualMinY = objetosGeneratorRampa.minY;
        float actualMinZ = objetosGeneratorRampa.minZ;
        float actualMaxZ = objetosGeneratorRampa.maxZ;

        // Assert
        Assert.LessOrEqual(actualMinX, actualMaxX, "minX debe ser menor o igual a maxX.");
        Assert.LessOrEqual(actualMinZ, actualMaxZ, "minZ debe ser menor o igual a maxZ.");
      Debug.Log($"Actual minX: {actualMinX}, Actual maxX: {actualMaxX}");
        Debug.Log($"Actual minZ: {actualMinZ}, Actual maxZ: {actualMaxZ}");

  
    }
}