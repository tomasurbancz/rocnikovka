using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{

    public AudioClip musicClip;
    private AudioSource audioSource;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.2f;

        audioSource.Play();

    }
}
