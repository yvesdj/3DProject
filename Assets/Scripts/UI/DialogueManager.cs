using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public Animator animator;

    private Queue<string> _sentences;
    public bool isConversating;

    // Start is called before the first frame update
    void Start()
    {
        _sentences = new Queue<string>();
    }

    void Update()
    {
        if (isConversating)
        {
            DisplayNextOnInput();
        }
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        _sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            _sentences.Enqueue(sentence);
        }

        isConversating = true;
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentenceToDisplay));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
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
        animator.SetBool("IsOpen", false);
        isConversating = false;
        Debug.Log("Ended conversation");
    }
}
