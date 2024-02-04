using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float velocidad;
    [SerializeField, Range(0, 100)] private float salto;
    [SerializeField] private int saltosMax;
    [SerializeField] private int contadorSaltos;
    [SerializeField] private LayerMask capaSuelo;
    [SerializeField] private BoxCollider2D colliderPies;
    private bool direccion = true;
    private Rigidbody2D rb2D;
    private Animator animaciones;
    
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

    public void Animaciones()
    {
        //ANIMACIONES DEL HOMBRE 


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
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) // CAMBIO DE ANIMACION DE MOVIMIENTO A QUIETO 
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKeyDown(KeyCode.Space)) // SALTA
        {
            animaciones.SetInteger("cambioEstado", 6);
            
        }

        //ANIMACION DEL LOBO

        if (Input.GetKey(KeyCode.X)) // ANIMACION DE SE TRANSFORMA
        {
            animaciones.SetInteger("cambioEstado", 1);
            animaciones.SetBool("transformacion", true);
        }

        if (animaciones.GetBool("transformacion") == true && Input.GetKey(KeyCode.D)) // ANIMACION DE MOVIMIENTO COMO LOBO
        {
            animaciones.SetInteger("cambioEstado", 10);
        }

        if (animaciones.GetBool("transformacion") == true && Input.GetKeyUp(KeyCode.D)) // CAMBIO DE ANIMACION DE MOVIMIENTO COMO LOBO COMO IDE LOBO
        {
            animaciones.SetInteger("cambioEstado", 1);
        }

        if (Input.GetKey(KeyCode.X) && Input.GetKey(KeyCode.A)) // ANIMACION DE SE TRANSFORMA
        {
            animaciones.SetInteger("cambioEstado", 10);
            animaciones.SetBool("transformacion", true);
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
