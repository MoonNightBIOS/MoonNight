using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuPrincipal : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("SegundoNivel", LoadSceneMode.Single);
    }
    public void Opciones()
    {
        SceneManager.LoadScene("MenuOpciones", LoadSceneMode.Additive);
    }
    public void Salir()
    {
        Application.Quit();
    }

}
