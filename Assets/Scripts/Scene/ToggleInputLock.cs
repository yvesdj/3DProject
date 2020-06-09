using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleInputLock : MonoBehaviour, IEventTrigger
{
    public bool HasBeenTriggered { get; set; }
    public static GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        HasBeenTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<DialogueManager>().isConversating == false && HasBeenTriggered)
        {
            player.GetComponent<PlayerInput>().IsEnabled = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        HasBeenTriggered = true;
        player.GetComponent<PlayerMovement>().moveVector = new Vector3(0, 0, 0);
        player.GetComponent<PlayerInput>().IsEnabled = false;
        Debug.Log(player.GetComponent<PlayerMovement>().moveVector);
    }
}
