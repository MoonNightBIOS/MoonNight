using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables
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
            transform.position -= new Vector3 (movimiento * Time.deltaTime, 0f, 0f);
            animaciones.SetInteger("cambioEstado", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3 (movimiento * Time.deltaTime, 0f, 0f);
            animaciones.SetInteger("cambioEstado", 2);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3 (0f, movimiento * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3 (0f, movimiento * Time.deltaTime, 0f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.AddForce(new Vector2 (0f, 10f), ForceMode2D.Impulse);
            animaciones.SetInteger("cambioEstado", 3);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            animaciones.SetInteger("cambioEstado", 0);
        }
    }
}
