using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OntriggerCollider : MonoBehaviour
{
    public GameObject UIObject;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
{
        UIObject.SetActive(true);
        Debug.Log("Contacto");
    
}



}