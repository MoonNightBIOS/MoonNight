using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMov : MonoBehaviour
{
    [SerializeField] Camera camara;
    [SerializeField] GameObject jugador;
    

    void Start()
    {
       camara = GetComponent<Camera>();
       
      
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoCamara();
    }


    void MovimientoCamara() 
    {
        camara.transform.position = new Vector2(jugador.transform.position.x, jugador.transform.position.y);
    }

}
