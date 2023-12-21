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
    [SerializeField] TMP_Dropdown comboboxCalidad;
    [SerializeField] TMP_Dropdown comboboxResolucion;
    [SerializeField] float volumenValor;
    [SerializeField] float brilloValor;
    [SerializeField] int valorCalidad;
    Resolution[] resoluciones;


    void Start()
    {
        Sonido();
        Mute();
        Pantalla();
        Brillo();
        Calidad();
        RevisarResoluciones();

    }

    void Sonido()
    {
        barraVolumen.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        AudioListener.volume = barraVolumen.value;
    }


    void Brillo()
    {
        barraBrillo.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        alpha.color = new Color(alpha.color.r, alpha.color.g, alpha.color.b, barraBrillo.value);
    }

    void Pantalla()
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

    void Calidad()
    {
        valorCalidad = PlayerPrefs.GetInt("valorBox", 3);
        comboboxCalidad.value = valorCalidad;

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

    public void CambiarCalidad()
    {
        QualitySettings.SetQualityLevel(comboboxCalidad.value);
        PlayerPrefs.SetInt("valorBox", comboboxCalidad.value);
        valorCalidad = comboboxCalidad.value;
    }

    public void RevisarResoluciones()
    {
        resoluciones = Screen.resolutions;
        comboboxResolucion.ClearOptions();
        List<string> opciones = new List<string>();
        int resolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opc = resoluciones[i].width + "X" + resoluciones[i].height;
            opciones.Add(opc);

            if(Screen.fullScreen && resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                resolucionActual = i;
            }
        }
        comboboxResolucion.AddOptions(opciones);
        comboboxResolucion.value = resolucionActual;
        comboboxResolucion.RefreshShownValue();
        comboboxResolucion.value = PlayerPrefs.GetInt("ResolucionIndex", 0);

    }
    public void CambiarResoluciones( int indexRes)
    {
        PlayerPrefs.SetInt("ResolucionIndex", comboboxResolucion.value);
        Resolution resolucion = resoluciones[indexRes];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

    public void Volver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}

