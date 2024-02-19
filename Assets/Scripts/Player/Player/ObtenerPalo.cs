using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObtenerPalo : MonoBehaviour
{

    public GameObject paloScene;
    public GameObject paloMano;
    
    // Start is called before the first frame update
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Palo") 
        {
            paloMano.SetActive(true);
            paloScene.SetActive(false);
        }
    }
}
