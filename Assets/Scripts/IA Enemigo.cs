using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAEnemigo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Blanco;
    int DistanciaMin = 5;
    private Transform Incial;
    public float Velocidad = 1.0f;

    void Start()
    {
        Incial = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Blanco.transform.position, this.transform.position)< DistanciaMin)
        {
            print("Ataca");
            transform.position = Vector3.MoveTowards(transform.position, Blanco.transform.position, Velocidad * Time.deltaTime);

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Incial.transform.position, Velocidad * Time.deltaTime);
        }

    }
}
