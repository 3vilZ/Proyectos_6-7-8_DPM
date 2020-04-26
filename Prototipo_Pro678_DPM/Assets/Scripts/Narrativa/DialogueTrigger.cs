using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void Awake()
    {
        //DontDestroyOnLoad(this);
        foreach (AudioConfig audio in dialogue.audioConfigs)
        {
            audio.source = gameObject.AddComponent<AudioSource>();
            audio.source.clip = audio.clip;
            audio.source.volume = audio.volume;
            audio.source.pitch = audio.pitch;
            audio.source.loop = audio.loop;
        }
    }

    public void TriggerDialogue()
    {
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().StartConversation(dialogue);
    }
}
