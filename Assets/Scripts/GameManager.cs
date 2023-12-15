using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    //[SerializeField] MenuManager menuManager;

    public void Awake()
    {
        if (GameManager.gameManager == null)
        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }


    void Start()
    {
        CargarManager();
    }



    void CargarManager()
    {
       // this.menuManager = GameObject.FindObjectOfType<MenuManager>();
        Time.timeScale = 1f;
    }


}

