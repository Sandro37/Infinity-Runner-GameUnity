using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomEfeitos : MonoBehaviour
{
    public AudioClip somTiro;
    public AudioClip somPulo;
    public AudioClip DanoPlayer;

    private AudioSource audioSource;

    public static SomEfeitos audio;

    private void Start()
    {
        audio = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void TocarSom(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
