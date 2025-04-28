using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public AudioClip[] Songs;
    private AudioSource audioSource;
    private int currentSongIndex = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f;

        PlayNextSong();
    }

    private void PlayNextSong()
    {
        audioSource.clip = Songs[currentSongIndex];
        audioSource.Play();

        currentSongIndex = (currentSongIndex + 1) % Songs.Length;

        Invoke("PlayNextSong", audioSource.clip.length);
    }
}
