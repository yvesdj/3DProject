using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IEventTrigger
{
    public bool HasBeenTriggered { get; set; }
    //public bool IsElapsed { get; set; }

    private float timer;
    public float respawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        HasBeenTriggered = false;

        timer = 0;
    }

    void Update()
    {
        StartRespawning();
    }

    public void StartRespawning()
    {
        if (HasBeenTriggered == true)
        {
            if (HasBeenTimed())
            {
                HasBeenTriggered = false;
                TogglePickupVisibility();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        HasBeenTriggered = true;
        EnhancePlayer(other);
    }

    private void EnhancePlayer(Collider player)
    {
        Debug.Log("Enhance player");
        TogglePickupVisibility();
    }

    public void TogglePickupVisibility()
    {
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        GetComponent<Collider>().enabled = !GetComponent<Collider>().enabled;
    }

    public bool HasBeenTimed()
    {
        timer += Time.deltaTime;
        if (timer >= respawnTime)
        {
            timer = 0;
            return true;
        }
        else return false;
    }

}
