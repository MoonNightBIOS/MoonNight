using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables
    public float velocidad; 
    Animator animaciones;
    Rigidbody2D rb2D;
    SpriteRenderer personaje;
    bool giro;

    void Start()
    { 
        animaciones = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        personaje = GetComponent<SpriteRenderer>();
    }

    // Teclas para Movimiento
    void Update()
    {

        if (Input.GetKey(KeyCode.A)) //MOVIMIENTO A LA IZQUIERDA
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
            animaciones.SetInteger("cambioEstado", 3);
            personaje.flipX = true;
            giro = true;
        }

        if (Input.GetKeyUp(KeyCode.A)) // CAMBIO DE ANIMACION A QUIETO
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKey(KeyCode.D)) // MOVIMIENTO A LA DERECHA
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
            animaciones.SetInteger("cambioEstado", 3);
            personaje.flipX = false;
            giro = false;
        }

        if (Input.GetKeyUp(KeyCode.D)) // CAMBIO DE ANIMACION A QUIETO
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space)) // SALTA
        {
            if (giro == false)
            {
                rb2D.AddForce(new Vector2(3f, 5f), ForceMode2D.Impulse);
                animaciones.SetInteger("cambioEstado", 6);
            }
            else
            {
                rb2D.AddForce(new Vector2(-3f, 5f), ForceMode2D.Impulse);
                animaciones.SetInteger("cambioEstado", 6);
            }
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
