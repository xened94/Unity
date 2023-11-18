using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OtroScript : MonoBehaviour
{
    private DataInsertionScript dataInsertionScript;
    string level = "Izquierda";
    string nombreDeLaEscena = SceneManager.GetActiveScene().name;
    private void Start()
    {
        // Encuentra el objeto que tiene el script de inserción de datos
        dataInsertionScript = FindObjectOfType<DataInsertionScript>();
    }

    private void AlgunMetodoDondeQuieresInsertarDatos()
    {
        if (dataInsertionScript != null)
        {
               // Obtiene el nombre de la escena actual
            string nombreDeLaEscena = SceneManager.GetActiveScene().name;
            // Puedes llamar al método de inserción de datos desde aquí
               dataInsertionScript.InsertarDatosDelJuego(100, nombreDeLaEscena,level, 30.0f, 10, 1,"PlayerName");
        }
        else
        {
            Debug.LogError("No se encontró un objeto con DataInsertionScript en la escena.");
        }
    }
}