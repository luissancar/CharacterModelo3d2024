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
    public bool cerca;
    public float distancia;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        //float tiempoAleatorio = Random.Range(-0.9f, 1.5f);
        //anim.speed = tiempoAleatorio;
        cerca = false;
    }


    private void Update()
    {
        distancia = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distancia);
        if (distancia < 4 && !cerca)
        {
            anim.SetBool("Cerca", true);
            cerca = true;
        }

        if (distancia >= 4 && cerca)
        {
            anim.SetBool("Cerca", false);
            cerca = false;
        }


        if (player != null)
        {
            transform.LookAt(player.transform);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetTrigger("Golpeado");
        }
    }
}