using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class regresarprincipal: MonoBehaviour
{
    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene("Configuraciones");
    }
}