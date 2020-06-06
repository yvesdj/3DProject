using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    private bool _hasBeenTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        TriggerDialogue();
    }


    public void TriggerDialogue()
    {
        if (_hasBeenTriggered == false)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            _hasBeenTriggered = true;
        }
        else
        {
            return;
        }
        
    }
}
