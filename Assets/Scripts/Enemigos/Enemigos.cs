using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    // Start is called before the first frame update

    RaycastHit2D obstaculo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Detectar al Player (sigue sin funcionar)
        if(Input.GetKeyDown(KeyCode.Space))
        {
           obstaculo=Physics2D.Raycast(transform.position, transform.forward, 10f);
            if (obstaculo)
            {
                Debug.Log("Se detecto Player");

                // Nombre de con que Choco el Rayo

                Debug.Log("Sw detecto : " + obstaculo.transform.gameObject.name);

                // Obtener la ditancia

                Debug.Log("Distancia al Objeto: " + obstaculo.distance);
            }
        } 
        
    }
}
