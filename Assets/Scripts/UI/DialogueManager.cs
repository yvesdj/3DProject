using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> _sentences;
    private bool _isConversating;

    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
    }

    void Update()
    {
        if (_isConversating)
        {
            DisplayNextOnInput();
        }
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        _sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        _isConversating = true;
        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentenceToDisplay = _sentences.Dequeue();
        Debug.Log(sentenceToDisplay);
    }

    private void DisplayNextOnInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    private void EndDialogue()
    {
        _isConversating = false;
        Debug.Log("Ended conversation");
    }
}
