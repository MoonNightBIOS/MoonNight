using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamara : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 diff;
    float rotz;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousepos = Input.mousePosition;
        diff = Camera.main.ScreenToWorldPoint(mousepos) - transform.position;
        diff.Normalize();


        rotz = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
    }
}
