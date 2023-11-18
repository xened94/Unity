using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonTablaPuntuaciones : MonoBehaviour
{
    public void CargarTablaPuntuaciones()
    {
        SceneManager.LoadScene("TablaPuntuacionesScene"); // Reemplaza con el nombre de tu escena de tabla de puntuaciones
    }
}