using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlDeNombre : MonoBehaviour
{
    public InputField inputNombre;
    public Button botonConfirmar;
    public Text mensajeFinal;
    public Recolectar recolectarScript; // Variable para la referencia al script Recolectar

private void Start()
{
    // Agrega un listener al botón de confirmar.
    botonConfirmar.onClick.AddListener(ConfirmarNombre);
}

    public void ConfirmarNombre()
    {
        string nombre = inputNombre.text;
        Debug.Log("Nombre: " + nombre);
        recolectarScript.SetNombre(nombre); // Asigna el nombre al script Recolectar.
        mensajeFinal.text = "¡Felicidades, " + nombre + "! Obtuviste " + recolectarScript.puntajeTotal + " puntos.";
    }
}
