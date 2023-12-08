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
        pausa();
    }

    public void pausa()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void reanudar()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Menu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
