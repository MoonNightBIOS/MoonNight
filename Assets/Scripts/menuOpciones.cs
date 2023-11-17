using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class menuOpciones : MonoBehaviour
{

    public Toggle toggle;
    public TMP_Dropdown dropdown;
    public int calidad;
    public TMP_Dropdown resolucionesDropdown;
    Resolution[] resoluciones;
    void Start()
    {

        calidad = PlayerPrefs.GetInt("IndexCalidad", 3);
        dropdown.value = calidad;
        Calidad();
        resolucion();

        if (Screen.fullScreen)
        {
            toggle.isOn = true;
        }
        else
        {
            toggle.isOn = false;
        }


    }


    void Update()
    {

    }


    public void PantallaCompleta(bool Pantalla)
    {
        Screen.fullScreen = Pantalla;
    }

    public void Calidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("IndexCalidad", dropdown.value);
        calidad = dropdown.value;
    }

    public void resolucion()
    {
        resoluciones = Screen.resolutions;
        resolucionesDropdown.ClearOptions();
        List<string> opciones = new List<string>();
        int ResolucionActual = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string opcion = resoluciones[i].width + " x " + resoluciones[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resoluciones[i].width ==
                Screen.currentResolution.width && resoluciones[i].height ==
                Screen.currentResolution.height)
            {
                ResolucionActual = i;
            }

        }

        resolucionesDropdown.AddOptions(opciones);
        resolucionesDropdown.value = ResolucionActual;
        resolucionesDropdown.RefreshShownValue();

        resolucionesDropdown.value = PlayerPrefs.GetInt("NumeroResolucion", 0);


    }


    public void CambiarResolucion(int indiceResolucion)
    {
        PlayerPrefs.SetInt("NumeroResolucion", resolucionesDropdown.value);

        Resolution resolucion = resoluciones[indiceResolucion];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }

}

