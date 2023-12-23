using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables
    [SerializeField] float velocidad;
    [SerializeField] float salto;
    Animator animaciones;
    Rigidbody2D rb2D;
    SpriteRenderer personaje;
    bool giro = true;
    bool piso = true;

    void Start()
    {
        velocidad = 4f;
        salto = 6f;
        this.animaciones = GetComponent<Animator>();
        this.rb2D = GetComponent<Rigidbody2D>();
        this.personaje = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Moverse();
        Animaciones();
    }


    // MECANICAS
    public void Moverse()
    {

        float Horizontal = Input.GetAxis("Horizontal");

        rb2D.velocity = new Vector2(Horizontal * velocidad, rb2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && piso == true) // SALTA
        {
            if (giro == false)
            {
                rb2D.AddForce(new Vector2(-1f, salto), ForceMode2D.Impulse);
            }
            else
            {
                rb2D.AddForce(new Vector2(1f, salto), ForceMode2D.Impulse);
            }
        }

        
    }
    
    public void Animaciones()
    {
        //ANIMACIONES

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) // ANIMACION DE MOVIMIENTO A LA IZQUIERDA
        {
            animaciones.SetInteger("cambioEstado", 3);
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)) // CAMBIO DE ANIMACION A QUIETO
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) // MOVIMIENTO A LA DERECHA
        {
            animaciones.SetInteger("cambioEstado", 3);
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) // CAMBIO DE ANIMACION A QUIETO
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) // SALTA
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

        if (Input.GetKeyUp(KeyCode.Z)) // CANCELACION DE LA ANIMACION DE ATAQUE
        {
            animaciones.SetInteger("cambioEstado", 0);
        }
    }
}
