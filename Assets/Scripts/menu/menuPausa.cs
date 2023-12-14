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
            Time.timeScale = 0f;
            menu.SetActive(true);
        }
    }

    public void reanudar()
    {
        Time.timeScale = 1f;
        menu.SetActive(false);
    }

    public void opciones()
    {

    }
}
