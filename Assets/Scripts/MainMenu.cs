using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    public InputField nombreInput;
   private void Start()
    {
        // Verificar si ya hay un nombre almacenado en PlayerPrefs
        if (PlayerPrefs.HasKey("NombreJugador"))
        {
            // Si hay un nombre almacenado, cargarlo y mostrarlo en el input
            string nombreGuardado = PlayerPrefs.GetString("NombreJugador");
            nombreInput.text = nombreGuardado;
        }
    }
    public void Laberinto()
    {
        if (!string.IsNullOrEmpty(nombreInput.text))
        {
            // Guarda el nombre en PlayerPrefs.
            PlayerPrefs.SetString("PlayerName", nombreInput.text);
            // Luego, carga la escena deseada.
            SceneManager.LoadScene("Laberinto");
        }
        else
        {
            Debug.Log("El campo de nombre está vacío. Por favor, ingresa un nombre.");
        }
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void EnProgreso()
    {
        if (!string.IsNullOrEmpty(nombreInput.text))
        {
            PlayerPrefs.SetString("PlayerName", nombreInput.text);
            SceneManager.LoadScene("RunDodge");
        }
        else
        {
            Debug.Log("El campo de nombre está vacío. Por favor, ingresa un nombre.");
        }
    }

    public void UpDown()
    {
        if (!string.IsNullOrEmpty(nombreInput.text))
        {
            PlayerPrefs.SetString("PlayerName", nombreInput.text);
            SceneManager.LoadScene("UpDown");
        }
        else
        {
            Debug.Log("El campo de nombre está vacío. Por favor, ingresa un nombre.");
        }
    }
    public void ConfirmarNombre()
{
    string nombre = nombreInput.text;
     PlayerPrefs.SetString("NombreJugador", nombre); // Guarda el nombre en PlayerPrefs
    PlayerPrefs.Save();

}

    public void BotonIzquierdaPresionado()
    {
        PlayerPrefs.SetInt("UsarMovimientoIzquierda", 1); // 1 para izquierda, 0 para derecha
        SceneManager.LoadScene("Main Menu");
    }

    public void BotonDerechaPresionado()
    {
        PlayerPrefs.SetInt("UsarMovimientoIzquierda", 0);
        SceneManager.LoadScene("Main Menu");
    }


}