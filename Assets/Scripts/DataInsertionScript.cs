using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInsertionScript : MonoBehaviour
{
    public DatabaseManager databaseManager;

    // Otros campos y métodos según sea necesario

    public void InsertarDatosDelJuego(int score, string miniGameName, string level, float time, int objectCount, int tratamiento, string playerName)
    {
        if (databaseManager != null)
        {
            // Puedes obtener la información necesaria de otras variables en tu juego
            // Por ejemplo, para obtener el nombre de la escena actual
            string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

            // Ahora llamamos a la función InsertarDatosDelJuego
            databaseManager.InsertarDatosDelJuego(score, currentSceneName, level, time, objectCount, tratamiento, playerName);
        }
        else
        {
            Debug.LogError("La referencia a DatabaseManager es nula.");
        }
    }

    // Otros métodos según sea necesario
}