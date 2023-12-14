using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJugador : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2d(Collider2D Col)
    {
        if (Col.gameObject.tag == "Enemigo") 
        {
            Debug.Log("Colisiona");
            Col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

    }
}
