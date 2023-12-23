using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables
    [SerializeField, Range(0, 100)] float velocidad;
    [SerializeField, Range(0, 100)] float salto;
    [SerializeField] LayerMask capaSuelo;
    Animator animaciones;
    Rigidbody2D rb2D;
    [SerializeField] BoxCollider2D colliderPies;
    bool direccion = true;
   // bool piso = true;

    void Start()
    {
        velocidad = 6f;
        salto = 12f;
        this.animaciones = GetComponent<Animator>();
        this.rb2D = GetComponent<Rigidbody2D>();
        this.colliderPies=GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        Moverse();
        Salto();
        Animaciones();
    }


    // MECANICAS
    public void Moverse()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        rb2D.velocity = new Vector2(Horizontal * velocidad, rb2D.velocity.y);
        Orientacion(Horizontal);
    }

    public void Salto()
    {
        if (/*Input.GetKeyDown(KeyCode.Space) ||*/ Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && Suelo()) // MECANICA DE SALTO
        {
            rb2D.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
        }
    }

    void Orientacion(float dir)
    {
        if ((direccion == true && dir < 0) || (direccion == false && dir > 0))
        {
            direccion = !direccion;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    bool Suelo()
    {
     RaycastHit2D rayo = Physics2D.BoxCast(colliderPies.bounds.center, new Vector2(colliderPies.bounds.size.x, colliderPies.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
     return rayo.collider != null;
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

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) && Suelo()) // SALTA
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
