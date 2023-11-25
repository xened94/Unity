using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using dbpruebas;
using System.Data;
using System;

[TestFixture]
public class Dbtesting
{
    [Test]
    public void InsertarDatosDelJuego_InsertsDataSuccessfullyWithParameters()
    {
        // Arrange
        var go = new GameObject();
        var databaseManager = go.AddComponent<DatabaseManager>();
        databaseManager.OpenConnectionForTesting("URI=file::memory:"); // Usa una base de datos en memoria para las pruebas

        // Act
        databaseManager.InsertarDatosDelJuego(100, "MiniGame1", "Level1", 10.5f, 20, 1, "Player1");

        // Assert
        // Agrega aserciones para verificar que los datos se insertaron correctamente
        // Puedes consultar la base de datos en memoria para verificar los resultados esperados
        IDbCommand dbCommand = databaseManager.DbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT COUNT(*) FROM treatment_data WHERE playerName = 'Player1'";
        var result = Convert.ToInt32(dbCommand.ExecuteScalar());

        // Añadir un Debug.Log para imprimir el resultado
        Debug.Log($"Número de filas en la tabla treatment_data para playerName='Player1': {result}");

        Assert.IsTrue(result > 0, "Se esperaba que se insertara al menos una fila en la tabla treatment_data para playerName='Player1'");

        // Cleanup
        databaseManager.CloseConnectionForTesting();
        GameObject.DestroyImmediate(go);
    }
}
