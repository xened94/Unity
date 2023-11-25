using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using laberinto;

[TestFixture]
public class CajaNegraLab
{
    [Test]
    public void LabWidth_Succeeds()
    {
        // Arrange
        var mazeGeneratorObject = new GameObject();
        var mazeGenerator = mazeGeneratorObject.AddComponent<MazeGenerator>();

        // Act
        int actualMazeWidth = mazeGenerator.MazeWidth;

        // Debug
        Debug.Log("Actual Maze Width: " + actualMazeWidth);

        // Assert
        Assert.AreEqual(20, actualMazeWidth);
    }

    [Test]
    public void LabDepth_Succeeds()
    {
        // Arrange
        var mazeGeneratorObject = new GameObject();
        var mazeGenerator = mazeGeneratorObject.AddComponent<MazeGenerator>();

        // Act
        int actualMazeDepth = mazeGenerator.MazeDepth;

        // Debug
        Debug.Log("Actual Maze Depth: " + actualMazeDepth);

        // Assert
        Assert.AreEqual(20, actualMazeDepth);
    }

    [Test]
    public void ManzanasCount_Succeeds()
    {
        // Arrange
        var mazeGeneratorObject = new GameObject();
        var mazeGenerator = mazeGeneratorObject.AddComponent<MazeGenerator>();

        // Act
        int actualManzanasCount = mazeGenerator.numberOfManzanas;

        // Debug
        Debug.Log("Actual Manzanas Count: " + actualManzanasCount);

        // Assert
        Assert.AreEqual(20, actualManzanasCount);
    }
}
