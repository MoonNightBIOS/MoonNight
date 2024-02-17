using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    // Start is called before the first frame update

    RaycastHit2D Obstaculo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           Obstaculo=Physics2D.Raycast(transform.position, transform.forward, 10f);
            if (Obstaculo)
            {
                Debug.Log("Se detecto Player");
            }
        } 
        
    }
}
