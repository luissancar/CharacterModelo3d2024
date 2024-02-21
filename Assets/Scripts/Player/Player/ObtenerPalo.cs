using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObtenerPalo : MonoBehaviour
{

    public GameObject paloScene;
    public GameObject paloMano;

    public bool tengoPalo;
    
    // Start is called before the first frame update
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Vector3 posicion = gameObject.transform.position;;
            paloScene.transform.position = new Vector3(posicion.x+2, posicion.y , posicion.z);
            paloMano.SetActive(false);
            paloScene.SetActive(true);
            tengoPalo = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Palo") 
        {
            paloMano.SetActive(true);
            paloScene.SetActive(false);
            tengoPalo = true;
        }
    }
}
