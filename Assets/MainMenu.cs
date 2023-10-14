using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  public void Laberinto()
    {
        SceneManager.LoadScene("Laberinto"); // Nombre de la escena que quieres cargar.
    }
        
         public void MenuPrincipal()
    {
        SceneManager.LoadScene("Main Menu"); // Nombre de la escena que quieres cargar.
    }
    public void Salir()
    {
        Application.Quit();
    }
   public void EnProgreso()
    {
        SceneManager.LoadScene("En progreso"); // Nombre de la escena que quieres cargar.
    }

       public void UpDown()
    {
        SceneManager.LoadScene("UpDown"); // Nombre de la escena que quieres cargar.
    }





}
