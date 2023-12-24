using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioClip clip;
    private Animator animaciones;

    [SerializeField, Range(0, 100)] private float velocidad;
    [SerializeField, Range(0, 100)] private float salto;
    [SerializeField] private int saltosMax;
    [SerializeField] private int contadorSaltos;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private BoxCollider2D colliderPies;
    private bool direccion = true;
    private Rigidbody2D rb2D;

    void Start()
    {
        saltosMax = 2;
        contadorSaltos = saltosMax;
        velocidad = 6f;
        salto = 12f;
        this.animaciones = GetComponent<Animator>();
        this.rb2D = GetComponent<Rigidbody2D>();
        this.colliderPies = GetComponent<BoxCollider2D>();
    }


    void Update()
    {
        Moverse();
        Salto();
        Animaciones();
        //ComprobarTransformacion();
    }


    // MECANICAS
    public void Moverse()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2(Horizontal * velocidad, rb2D.velocity.y);
        Orientacion(Horizontal);
    }

    void Orientacion(float dir)
    {
        if ((direccion == true && dir < 0) || (direccion == false && dir > 0))
        {
            direccion = !direccion;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }

    public void Salto() // MECANICA DE SALTO
    {
        if (Input.GetKeyDown(KeyCode.Space) && contadorSaltos > 1)
        {
            contadorSaltos--;
            rb2D.velocity = new Vector2(rb2D.velocity.x, 0f);
            rb2D.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
        }
        if (Suelo())
        {
            contadorSaltos = saltosMax;
        }
    }

    bool Suelo() // COMPROBAR QUE TOQUE EL SUELO 
    {
        RaycastHit2D rayo = Physics2D.BoxCast(colliderPies.bounds.center, new Vector2(colliderPies.bounds.size.x, colliderPies.bounds.size.y), 0f, Vector2.down, 0.5f, capaSuelo);
        return rayo.collider != null;
    }

    /* void ComprobarTransformacion()
     {
         if (Input.GetKey(KeyCode.X))
         {
             transformacion = true;
         }

         else if (Input.GetKey(KeyCode.C))
         {
             transformacion = false;
         }
     }*/

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

        if (Input.GetKey(KeyCode.Space) && contadorSaltos > 1) // SALTA
        {
            animaciones.SetInteger("cambioEstado", 6);

        }

        if (Input.GetKey(KeyCode.X)) // ANIMACION DE SE TRANSFORMA
        {
            animaciones.SetInteger("cambioEstado", 1);
            animaciones.SetBool("transformacion", true);
            AudioManager.audioManager.Reproducir(clip);
        }

        if (Input.GetKey(KeyCode.C)) // ANIMACION DE SE DESTRANSFORMA
        {
            animaciones.SetInteger("cambioEstado", 2);
            animaciones.SetBool("transformacion", false);
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
