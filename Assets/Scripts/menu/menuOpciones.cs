using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class menuOpciones : MonoBehaviour
{
    [SerializeField] Slider barraVolumen;
    [SerializeField] Slider barraBrillo;
    [SerializeField] Image alpha;
    [SerializeField] Image imagenMute;
    [SerializeField] Toggle botonPantalla;
    [SerializeField] float volumenValor;
    [SerializeField] float brilloValor;

    
    void Start()
    {
        Sonido();
        Mute();
        Pantalla();
        Brillo();
    }

    public void Pantalla()
    {
        if (Screen.fullScreen)
        {
            botonPantalla.isOn = true;
        }
        else
        {
            botonPantalla.isOn = false;
        }
    }

    public void Sonido()
    {
        barraVolumen.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = barraVolumen.value;
    }
    public void Brillo()
    {
        barraBrillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        alpha.color = new Color(alpha.color.r, alpha.color.g, alpha.color.b, barraBrillo.value);
    }

    public void MoverBarraVolumen(float valor)
    {
        volumenValor = valor;
        PlayerPrefs.SetFloat("volumenAudio", volumenValor);
        AudioListener.volume = barraVolumen.value;
        Mute();
    }

    public void MoverBarraBrillo(float valor)
    {
        volumenValor = valor;
        PlayerPrefs.SetFloat("brillo", brilloValor);
        alpha.color = new Color(alpha.color.r, alpha.color.g, alpha.color.b, barraBrillo.value);

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

    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }


    public void Volver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

