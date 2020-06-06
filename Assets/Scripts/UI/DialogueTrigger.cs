using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IEventTrigger
{
    public Dialogue dialogue;
    //private bool _hasBeenTriggered = false;
    public bool hasBeenTriggered { get; set; }

    void Start()
    {
        hasBeenTriggered = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
    }


    public void TriggerDialogue()
    {
        if (hasBeenTriggered == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            hasBeenTriggered = true;
        }
        else
        {
            return;
        }
        
    }
}
