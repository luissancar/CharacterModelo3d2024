using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//
public class LogicaObjetivos : MonoBehaviour
{
    public int numDeObjetivos;
    public TextMeshProUGUI textoMision;

    public GameObject botonDeMision;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void InicializarEsferas()
    {
        
        numDeObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Esferas restantes " + numDeObjetivos;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "objetivo")
        {
            Destroy(other.transform.parent.gameObject);
            numDeObjetivos--;
            textoMision.text = "Esferas restantes " + numDeObjetivos;
            if (numDeObjetivos <= 0)
            {
                textoMision.text = "Objetivo cumplido";
                botonDeMision.SetActive(true);
            }
        }
    }
}