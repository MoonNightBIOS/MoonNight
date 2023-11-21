using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadorAtaque : MonoBehaviour
{
    
    void Start()
    {
        
    }

    void Update()
    {
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector2.left) * 2f, Color.red);
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector2.right) * 2f, Color.red);
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector2.up) * 2f, Color.red);
        Debug.DrawRay(transform.position,transform.TransformDirection(Vector2.down) * 2f, Color.red);
        // Dibujamos el rayo

        RaycastHit2D hitizquierda = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.left) * 2f);
        RaycastHit2D hitderecha = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.right) * 2f);
        RaycastHit2D hitarriba = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.right) * 2f);
        RaycastHit2D hitabajo = Physics2D.Raycast(transform.position,transform.TransformDirection(Vector2.right) * 2f);
        // Creamos el rayo


        if(hitderecha.collider.tag == "Enemigo")
        {
            hitderecha.transform.GetComponent<SpriteRenderer>().color = Color.red;
            Destroy(hitderecha.transform.gameObject,1f);


        }





    }
}
