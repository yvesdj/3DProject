using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleGameObject : MonoBehaviour, IEventTrigger
{
    public bool HasBeenTriggered { get; set; }
    public GameObject objectToToggle;
    private bool _isActive;

    // Start is called before the first frame update
    void Start()
    {
        HasBeenTriggered = false;
        _isActive = objectToToggle.activeSelf;
    }

    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isConversating == false)
        {
            objectToToggle.SetActive(_isActive);
        }
    }

    private void ToggleActive()
    {
        if (HasBeenTriggered == false)
        {
            _isActive = !_isActive;
            HasBeenTriggered = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        ToggleActive();
    }

}
