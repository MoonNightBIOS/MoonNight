using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager { get; private set; }
    private AudioSource sonido;

    private void Awake()
    {
        if (AudioManager.audioManager == null)
        {
            AudioManager.audioManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        sonido = GetComponent<AudioSource>();
    }

   public void Reproducir(AudioClip clip)
    {
        sonido.PlayOneShot(clip);
    }
}
