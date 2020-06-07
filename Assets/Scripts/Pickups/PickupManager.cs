using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour, IEventTrigger
{
    private IPickup _pickup;

    public bool HasBeenTriggered { get; set; }

    private float timer;
    public float respawnTime;

    void Awake()
    {
        _pickup = GetComponent<IPickup>();
    }
    
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

        if (_pickup != null)
        {
            _pickup.EnhancePlayer(other);
        }
        else
        {
            Debug.Log("No effect chosen.");
        }

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
