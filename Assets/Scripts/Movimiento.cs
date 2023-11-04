using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Variables
    float movimiento;

    void Start()
    {
        movimiento = 10f;
    }

    // Teclas para Movimiento
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3 (movimiento * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(movimiento * Time.deltaTime, 0f, 0f);
        }
    }
}
