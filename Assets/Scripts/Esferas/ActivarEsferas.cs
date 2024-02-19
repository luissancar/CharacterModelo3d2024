using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarEsferas : MonoBehaviour
{
    public GameObject[] esferas;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void ActivaEsfera()
    {
        for (int i = 0; i < esferas.Length; i++)
        {
            esferas[i].SetActive(true);
            
        }
    }

}
