using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Dialogue
{
    /*
    [TextArea(3, 10)]
    public string[] sentence;

    [TextArea(3, 10)]
    public string sentence;

    public AudioClip clip;

    [Range(0, 1)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
    */

    [TextArea(3, 10)]
    public string[] sentence;

    public AudioConfig[] audioConfigs;

}
