using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlDePuntaje : MonoBehaviour
{
    public Text textoValorPuntaje;
    private int valorPuntaje = 10; // Valor predeterminado
    public InputField inputField;

    public void CambiarValorPuntaje(string nuevoValorTexto)
    {
        int nuevoValor;
        if (int.TryParse(inputField.text, out nuevoValor))
        {
            valorPuntaje = nuevoValor;
            ActualizarTextoValorPuntaje();
        }
        else
        {
            Debug.LogWarning("Valor no válido.");
        }
    }

private void ActualizarTextoValorPuntaje()
{
    textoValorPuntaje.text = "Valor Puntaje: " + valorPuntaje;
    Debug.Log("Valor del puntaje: " + valorPuntaje); // Agregar esta línea
}
}