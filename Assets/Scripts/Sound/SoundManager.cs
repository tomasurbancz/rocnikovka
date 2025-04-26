using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static List<string> ClipNames;
    private static List<AudioClip> Clips;

    public List<string> ClipNamesSetUp;
    public List<AudioClip> ClipsSetUp;

    private static AudioSource _audioSource;

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        ClipNames = ClipNamesSetUp;
        Clips = ClipsSetUp;
        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    public static void PlaySound(string name)
    {
        Debug.Log("TEST");
        Debug.Log(GetIndex(name));
        _audioSource.clip = Clips[GetIndex(name)];
        _audioSource.Play();
    }

    private static int GetIndex(string name)
    {
        for(int i = 0; i < ClipNames.Count; i++)
        {
            if (ClipNames[i].Equals(name)) return i;
        }
        return -1;
    }
}
