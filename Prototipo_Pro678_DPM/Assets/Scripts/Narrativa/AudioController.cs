using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioController : MonoBehaviour {

	public AudioConfig[] sounds;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
        foreach (AudioConfig audio in sounds)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.loop = audio.loop;
        }
    }
    /*
    void Start()
    {
        PlaySound("MusicMain");
    }
    
    public void PlaySound(string name)
    {
        AudioConfig audio = Array.Find(sounds, sound => sound.name == name);
        audio.source.Play();
    }
    */
}
