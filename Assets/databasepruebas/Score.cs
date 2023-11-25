using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace scorepruebas
{
public class Score : MonoBehaviour
{
    public Text scoreText;
    private float tiempoTotal;

    // Start is called before the first frame update
    void Start()
    {
        tiempoTotal = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        tiempoTotal += Time.deltaTime;
        scoreText.text = Mathf.FloorToInt(tiempoTotal).ToString();
    }

    // Llamado al finalizar el minijuego o cambiar de escena
    public float ObtenerTiempoTotal()
    {
        return tiempoTotal;
    }
}
}