using UnityEngine;
namespace reiniciarobjeto
{

public class ReiniciarObjeto : MonoBehaviour
{
    private Vector3 posicionInicial;
    private bool configurado = false;

public void Setup()
{
    if (!configurado)
    {
        // Guardar la posición inicial al inicio
        posicionInicial = transform.position;
        configurado = true;
        Debug.Log("Objeto configurado.");
    }
}

// Llamado desde ObjetosGenerator para reiniciar el objeto
public void Reiniciar()
{
    // Restablecer la posición
    transform.position = posicionInicial;

    // Activar el objeto
    gameObject.SetActive(true);

    Debug.Log("Objeto reiniciado.");
}
}
}