using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    

    void Update()
    {
        pausa();
    }

    public void pausa()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            menu.SetActive(true);            
        }
    }

    public void reanudar()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 1;
            menu.SetActive(false);            
        }
    }

    public void opciones()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 1;
            menu.SetActive(false);
        }
    }
}
