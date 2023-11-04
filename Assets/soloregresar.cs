using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class soloregresar : MonoBehaviour
{
    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }
}