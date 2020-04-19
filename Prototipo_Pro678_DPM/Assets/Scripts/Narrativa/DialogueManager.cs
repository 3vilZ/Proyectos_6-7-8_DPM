using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour {

    public Text dialogueText;

    private Queue<string> sentences;
    private Queue<AudioConfig> archivosAudio;

    AudioConfig audioConfig;
    bool bTalking = false;

    

    void Start()
    {
        sentences = new Queue<string>();
        archivosAudio = new Queue<AudioConfig>();
        dialogueText.enabled = false;
    }

    /*
    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();

      foreach (string sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }

  

        DisplayNextSentence();
        StartCoroutine("DisplaySentence");
    }

    public  IEnumerator DisplaySentence()
    {
        string sentence = sentences.ToString();

        foreach (char c in sentence)
        {
            dialogueText.text += c;

            yield return new WaitForSeconds(0.2f);            
        }

        DisplayNextSentence();
    }

    public IEnumerator TimerNextSentence()

    {
        yield return new WaitForSeconds(3f);
        DisplayNextSentence();
    }

    
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
            StartCoroutine("TimerNextSentence");
        }
    }
    */

    public void StartConversation(Dialogue dialogue)
    {
        dialogueText.enabled = true;
        bTalking = true;
        archivosAudio.Clear();

        foreach (AudioConfig aC in dialogue.audioConfigs)
        {
            archivosAudio.Enqueue(aC);
        }

        sentences.Clear();

        foreach (string sentence in dialogue.sentence)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (archivosAudio.Count == 0)
        {
            EndDialogue();
            return;
        }
        else
        {
            audioConfig = archivosAudio.Dequeue();
            string sentence = sentences.Dequeue();
            dialogueText.text = sentence;
            audioConfig.source.Play();
        }
    }

    private void Update()
    {
        if (archivosAudio.Count > 0)
        {
            if (!audioConfig.source.isPlaying)
            {
                DisplayNextSentence();
            }
        }
        else if (bTalking && archivosAudio.Count <= 0)
        {
            if (!audioConfig.source.isPlaying)
            {
                EndDialogue();
            }
                
        }
    }

    void EndDialogue()
    {
        dialogueText.enabled = false;
        bTalking = false;
    }
}
