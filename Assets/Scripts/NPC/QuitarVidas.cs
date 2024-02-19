using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class QuitarVidas : MonoBehaviour
{
    public GameObject PNC;
    public Image barraVidas;  // de unityEngine.ui
    private int vidaMax = 100;
    private float vidaActual;
    
    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMax;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vidaActual -= 10;
            barraVidas.fillAmount = vidaActual / vidaMax;
            if (vidaActual<=0)
            {
                Destroy(PNC,1f);
            }

        }
    }

    
}
