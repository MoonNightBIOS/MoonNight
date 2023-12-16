using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel-1");
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
