using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

///
public class PlayerController : MonoBehaviour
{
    // Movimientos basicos
    public float velocidadMovimiento = 5f;
    public float velocidadRotacion = 100f;
    public float x, y;

    // animacion
    public Animator anim;

    // Salto
    public Rigidbody rb;
    public float fuerzaSato = 80f;
    public bool puedoSaltar;

    public bool tocosuelo;

    public bool saltee;
    //


    // Agachado
    public float velocidaInicial;
    public float velocidadAgachado;
    //

    //Golpeo  Animación cross punch
    public bool estoyAtacando;
    public bool avanzoSolo;
    public float impulsoGolpe = 10f;

    // Correr
    public float velCorrer = 10f;


    // armas
    public bool conArma;


    //Cámaras
    public Camera cam1;
    public Camera cam2;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Salto
        puedoSaltar = true;
        //

        //Agachado
        velocidaInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
        //

        //Camaras
        cam1.enabled = true;
        cam2.enabled = false;

        //Atacando
        estoyAtacando = false;
        avanzoSolo = false;
    }

    private void FixedUpdate()
    {
        if (!estoyAtacando)
        {
            transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
            transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        }

        if (avanzoSolo)
        {
            rb.velocity = transform.forward * impulsoGolpe;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Correr
        Correr();


        // leemos cursores
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        //transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
        //transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);


        CambioCamara();
        // Golpeo
        Golpeo();
        Patada();

        //


        // pasamos datos para animacion
        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        // Salto
        if (!estoyAtacando)
        {
            Saltar();
            Agachado();
        }
    }

    private void Patada()
    {
        if (Input.GetKeyDown(KeyCode.P) && puedoSaltar )
        {
           
            {
                anim.SetTrigger("patada");
                estoyAtacando = true;
            }
        }
    }

    void CambioCamara()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cam1.enabled = true;
            cam2.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cam2.enabled = true;
            cam1.enabled = false;
        }
    }

    private void Golpeo()
    {
        if (Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !estoyAtacando)
        {
            /*   if (conArma)
               {
                   anim.SetTrigger("Golpeo2");
                   estoyAtacando = true;
               }
               else*/
            {
                anim.SetTrigger("golpeo");
                estoyAtacando = true;
            }
        }
    }

    private void Correr()
    {
        if (Input.GetKey(KeyCode.LeftShift) && puedoSaltar && !estoyAtacando)
        {
            velocidadMovimiento = velCorrer;
            if (y > 0)
            {
                anim.SetBool("Correr", true);
            }
            else
            {
                //         anim.SetBool("Correr", false);
                if (puedoSaltar)
                {
                    velocidadMovimiento = velocidaInicial;
                }
            }
        }
        else
        {
            //       anim.SetBool("Correr", false);
            velocidadMovimiento = velocidaInicial;
        }
    }

    private void Agachado()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            anim.SetBool("agachado", true);
            ///////////////////todo
            velocidadMovimiento = velocidadAgachado;
            ///
        }
        else
        {
            anim.SetBool("agachado", false);
            ///////////////////todo
            velocidadMovimiento = velocidaInicial;
            ///
        }
    }

    private void Saltar()
    {
        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("saltee", true);
                saltee = true;
                rb.AddForce(new Vector3(0, fuerzaSato, 0), ForceMode.Impulse);
            }

            anim.SetBool("tocoSuelo", true);
            tocosuelo = true;
        }
        else
        {
            EstoyCayendo();
        }
    }

    private void EstoyCayendo()
    {
        Debug.Log("cayendo");
        anim.SetBool("tocoSuelo", false);
        anim.SetBool("saltee", false);
        tocosuelo = false;
        saltee = false;
    }

    public void DejoDeGolpear()
    {
        estoyAtacando = false;
    }

    public void AvanzoSolo()
    {
        avanzoSolo = true;
    }

    public void DejoDeAvanzar()
    {
        avanzoSolo = false;
    }
}