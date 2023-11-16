using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuPausa : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    void Start()
    {
        Menu = GetComponent<GameObject>();
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
}
