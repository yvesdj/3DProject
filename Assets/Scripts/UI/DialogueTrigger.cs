using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour, IEventTrigger
{
    public bool shootable = false;
    public Dialogue dialogue;
    //private bool _hasBeenTriggered = false;
    public bool HasBeenTriggered { get; set; }
    
    void Start()
    {
        HasBeenTriggered = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
    }


    public void TriggerDialogue()
    {
        if (HasBeenTriggered == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            HasBeenTriggered = true;
        }
        else
        {
            return;
        }
        
    }
}
