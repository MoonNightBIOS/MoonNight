using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables
    public float velocidad; 
    Animator animaciones;
    Rigidbody2D rb2D;
    SpriteRenderer personaje;
    BoxCollider2D pies;
    bool giro = false;
    bool piso = true;

    void Start()
    { 
        this.animaciones = GetComponent<Animator>();
        this.rb2D = GetComponent<Rigidbody2D>();
        this.personaje = GetComponent<SpriteRenderer>();
        this.pies = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        Moverse();
        Animaciones();

    }


    // MECANICAS
    public void Moverse()
    {
        if (Input.GetKey(KeyCode.A)) //MOVIMIENTO A LA IZQUIERDA
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
            personaje.flipX = true;
            giro = true;
        }


        if (Input.GetKey(KeyCode.D)) // MOVIMIENTO A LA DERECHA
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            personaje.flipX = false;
            giro = false;
        }


        if (Input.GetKeyDown(KeyCode.Space)) // SALTA
        {
            if (giro == true)
            {
                rb2D.AddForce(new Vector2(-3f, 5f), ForceMode2D.Impulse);
            }
            else
            {
                rb2D.AddForce(new Vector2(3f, 5f), ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Piso")
        {
            piso = true;
        }
        else
        {
            piso = false;
        }
    }

    public void Animaciones()
    {
        //ANIMACIONES

        if (Input.GetKey(KeyCode.A)) // ANIMACION DE MOVIMIENTO A LA IZQUIERDA
        {
            animaciones.SetInteger("cambioEstado", 3);
        }
        else if (Input.GetKeyUp(KeyCode.A)) // CAMBIO DE ANIMACION A QUIETO
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKey(KeyCode.D)) // MOVIMIENTO A LA DERECHA
        {
            animaciones.SetInteger("cambioEstado", 3);
        }
        else if (Input.GetKeyUp(KeyCode.D)) // CAMBIO DE ANIMACION A QUIETO
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space)) // SALTA
        {
            animaciones.SetInteger("cambioEstado", 6);
        }

        if (Input.GetKey(KeyCode.X)) // ANIMACION DE SE TRANSFORMA
        {
            animaciones.SetInteger("cambioEstado", 1);
        }

        if (Input.GetKey(KeyCode.C)) // ANIMACION DE SE DESTRANSFORMA
        {
            animaciones.SetInteger("cambioEstado", 2);
        }

        if (Input.GetKey(KeyCode.Z)) // ANIMACION DE ATAQUE
        {
            animaciones.SetInteger("cambioEstado", 4);
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            animaciones.SetInteger("cambioEstado", 0);
        }
    }
}
