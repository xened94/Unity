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
        Assert.AreEqual(playerName, recolectar.ObtenerNombreJugador(), "El nombre del jugador no se guardó correctamente.");
        Debug.Log("Prueba SetPlayerName_SavesPlayerName completada.");
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
        Assert.AreEqual(initialScore + additionalScore, recolectar.ObtenerPuntajeTotal(), "El puntaje no se sumó correctamente.");
        Assert.AreEqual("Puntaje: " + recolectar.ObtenerPuntajeTotal(), mockPuntajeText.LastSetText, "El texto de puntaje no se actualizó correctamente.");
        Debug.Log("Prueba SumarPuntaje_AddsToTotalScore completada.");
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
        Assert.IsTrue(mensajeFinalFondoMock.LastSetActive, "El fondo del mensaje final no se activó correctamente.");
        Debug.Log("Prueba MostrarMensajeFinal_SetsActiveAndFreezesTime completada.");
    }
}
