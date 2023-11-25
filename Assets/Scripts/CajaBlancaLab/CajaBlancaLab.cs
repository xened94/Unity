using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using laberinto;

[TestFixture]
public class CajaBlancaLab
{
[Test]
public void GetCellAt_OutOfBounds()
{
    // Arrange
    var mazeGeneratorObject = new GameObject();
    var mazeGenerator = mazeGeneratorObject.AddComponent<MazeGenerator>();

   // Act & Assert
        Debug.Log("Prueba GetCellAt_OutOfBounds iniciada");

        Debug.Log("Coordenadas (-1, 0): " + mazeGenerator.GetCellAt(-1, 0));
        Assert.IsNull(mazeGenerator.GetCellAt(-1, 0), "Debe devolver null para coordenadas fuera de los límites.");

        Debug.Log("Coordenadas (0, -1): " + mazeGenerator.GetCellAt(0, -1));
        Assert.IsNull(mazeGenerator.GetCellAt(0, -1), "Debe devolver null para coordenadas fuera de los límites.");

        Debug.Log("Coordenadas (" + mazeGenerator.MazeWidth + ", 0): " + mazeGenerator.GetCellAt(mazeGenerator.MazeWidth, 0));
        Assert.IsNull(mazeGenerator.GetCellAt(mazeGenerator.MazeWidth, 0), "Debe devolver null para coordenadas fuera de los límites.");

        Debug.Log("Coordenadas (0, " + mazeGenerator.MazeDepth + "): " + mazeGenerator.GetCellAt(0, mazeGenerator.MazeDepth));
        Assert.IsNull(mazeGenerator.GetCellAt(0, mazeGenerator.MazeDepth), "Debe devolver null para coordenadas fuera de los límites.");

        Debug.Log("Prueba GetCellAt_OutOfBounds completada");

}
}
