using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class menuOpciones : MonoBehaviour
{
    [SerializeField] Slider barraVolumen;
    [SerializeField] float  volumenvalor;
    [SerializeField] Image  imagenMute;

    void Start()
    {
        barraVolumen.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = barraVolumen.value;
        Mute();

    }

    public void MoverBarra(float valor)
    {
        volumenvalor = valor;
        PlayerPrefs.SetFloat("volumenAudio", volumenvalor);
        AudioListener.volume = barraVolumen.value;
    }

    public void Mute()
    {

    }

    void Update()
    {

    }


}

