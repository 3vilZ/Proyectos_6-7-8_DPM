using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class AudioConfig
{
    public AudioClip clip;

    [Range(0, 1)]
    public float volume = 1;

    [Range(0.1f, 3f)]
    public float pitch = 1;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}

