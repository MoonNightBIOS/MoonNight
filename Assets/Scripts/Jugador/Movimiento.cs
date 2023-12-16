using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables
    public float velocidad; 
    Animator animaciones;
    Rigidbody2D rb2D;

    void Start()
    { 
        animaciones = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Teclas para Movimiento
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);            
        }

        //if (Input.GetKeyUp(KeyCode.A))
        //{
        //    animaciones.SetInteger("cambioEstado", 0);
        //}

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);           
        }

        //if (Input.GetKeyUp(KeyCode.D))
        //{
        //    animaciones.SetInteger("cambioEstado", 0);
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(new Vector2(3f, 5f), ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.X))
        {
            animaciones.SetInteger("cambioEstado", 1);
        }

        if (Input.GetKey(KeyCode.C))
        {
            animaciones.SetInteger("cambioEstado", 2);
        }
    }
}
