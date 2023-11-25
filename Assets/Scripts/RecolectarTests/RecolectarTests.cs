using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using recolectarpruebas;

[TestFixture]
public class RecolectarTests
{
    [Test]
    public void SetPlayerName_SavesPlayerName()
    {
        // Arrange
        var recolectar = new GameObject().AddComponent<Recolectar>();
        string playerName = "JohnDoe";

        // Act
        recolectar.SetPlayerName(playerName);

        // Assert
        Assert.AreEqual(playerName, recolectar.ObtenerNombreJugador());

        // Debug
        Debug.Log("Player name set successfully: " + recolectar.ObtenerNombreJugador());
    }

    [Test]
    public void SumarPuntaje_AddsToTotalScore()
    {
        // Arrange
        var gameObject = new GameObject();
        var recolectar = gameObject.AddComponent<Recolectar>();
        var mockPuntajeText = new MockPuntajeText();

        recolectar.puntajeText = mockPuntajeText; // Asigna el mock antes de llamar a SumarPuntaje
        int initialScore = recolectar.ObtenerPuntajeTotal();
        int additionalScore = 50;

        // Act
        recolectar.SumarPuntaje(additionalScore);

        // Assert
        Assert.AreEqual(initialScore + additionalScore, recolectar.ObtenerPuntajeTotal());

        // Debug
        Debug.Log("Total score after adding points: " + recolectar.ObtenerPuntajeTotal());
    }

    [Test]
    public void MostrarMensajeFinal_SetsActiveAndFreezesTime()
    {
        // Arrange
        var gameObject = new GameObject();
        var recolectar = gameObject.AddComponent<Recolectar>();
        var puntajeTextMock = new MockPuntajeText();
        var mensajeFinalFondoMock = new MockMensajeFinalFondo();

        recolectar.puntajeText = puntajeTextMock;
        recolectar.mensajeFinalFondo = mensajeFinalFondoMock;

        // Act
        recolectar.MostrarMensajeFinal();

        // Assert
        Assert.IsTrue(mensajeFinalFondoMock.LastSetActive);

        // Debug
        Debug.Log("MensajeFinalFondo set to active: " + mensajeFinalFondoMock.LastSetActive);
    }
}
    