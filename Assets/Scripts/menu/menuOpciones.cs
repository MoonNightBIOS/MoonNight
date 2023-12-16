using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuOpciones : MonoBehaviour
{
    [SerializeField] public Slider barraVolumen;
    [SerializeField] public float volumenValor;
    [SerializeField] public Image imagenMute;

    void Start()
    {
        barraVolumen.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = barraVolumen.value;
        Mute();
    }

    public void MoverBarra(float valor)
    {
        volumenValor = valor;
        PlayerPrefs.SetFloat("volumenAudio", volumenValor);
        AudioListener.volume = barraVolumen.value;
        Mute();
    }

    public void Mute()
    {
        if (volumenValor == 0)
        {
            imagenMute.enabled = true;
        }
        else
        {
            imagenMute.enabled = false;
        }
    }

   /* public void volver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }*/

}

