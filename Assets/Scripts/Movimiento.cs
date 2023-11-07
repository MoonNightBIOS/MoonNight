using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    Animator animaciones;
    // Variables
    float movimiento;

    void Start()
    { 
        animaciones = GetComponent<Animator>();
        movimiento = 10f;
    }

    // Teclas para Movimiento
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            animaciones.SetInteger("cambioEstado", 0);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            animaciones.SetInteger("cambioEstado", 1);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animaciones.SetInteger("cambioEstado", 2);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3 (movimiento * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3 (movimiento * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3 (0f, movimiento * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3 (0f, movimiento * Time.deltaTime, 0f);
        }
    }
}
