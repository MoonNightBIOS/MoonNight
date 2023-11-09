using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugar() 
    {
        SceneManager.LoadScene("PrimerNivel");
    }
    public void Opciones()
    {
        SceneManager.LoadScene("MenuOpciones");
    }
    public void Salir() 
    {
        Application.Quit();
    }

}
