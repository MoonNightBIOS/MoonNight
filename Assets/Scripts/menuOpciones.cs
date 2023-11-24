using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class menuOpciones : MonoBehaviour
{
    [SerializeField] Slider barraVolumen;
    [SerializeField] float  volumenValor;
    [SerializeField] Image  imagenMute;

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


}

