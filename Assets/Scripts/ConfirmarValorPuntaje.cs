using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmarValorPuntaje : MonoBehaviour
{
    public InputField inputValorPuntaje;
    public ControlDePuntaje controlDePuntaje;
    public GameObject inputPanel; // Este es el panel que contiene el input y el botón
    public GameObject mensajeTexto; // El objeto de texto para mostrar el mensaje

    public void ConfirmarNuevoValor()
    {
        string nuevoValorTexto = inputValorPuntaje.text;
        controlDePuntaje.CambiarValorPuntaje(nuevoValorTexto);

        // Desactivar el panel del input y el botón
        inputPanel.SetActive(false);

        // Mostrar el mensaje de multiplicador
        mensajeTexto.SetActive(true);
        mensajeTexto.GetComponent<Text>().text = "El multiplicador es x" + nuevoValorTexto;
    }
}