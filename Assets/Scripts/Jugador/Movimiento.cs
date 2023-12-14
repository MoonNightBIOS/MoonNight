using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables
    public float velocidad; 
    Animator animaciones;
    float movimiento;
    Rigidbody2D rb2D;

    void Start()
    { 
        animaciones = GetComponent<Animator>();
        movimiento = 8f;
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Teclas para Movimiento
    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);            
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);           
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * velocidad * Time.deltaTime);            
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(new Vector2 (0f, 10f), ForceMode2D.Impulse);            
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animaciones.SetInteger("cambioEstado", 0);
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
