using System;
using System.Collections;
using UnityEngine;
using static UnityEngine.Random;
using Random = UnityEngine.Random;

public class DetectarGolpe : MonoBehaviour
{
    //detectar player
    GameObject player;

    // animacion
    public Animator anim;
    public bool golpeado;
    public float distancia;

    //sonido
    private AudioSource sonido;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        sonido = GetComponent<AudioSource>();
        golpeado = false;
    }


    private void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distancia);
        if (distancia < 4 )
        {
            anim.SetBool("Cerca", true);
           
        }

        if (distancia >= 4)
        {
            anim.SetBool("Cerca", false);
           
        }


        if (player != null)
        {
            transform.LookAt(player.transform);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "puno" && 
            player.GetComponent<PlayerController>().estoyAtacando &&
            !golpeado)
        {
            sonido.Play();
            anim.SetTrigger("Golpeado");
            golpeado = true;
        }
    }
}