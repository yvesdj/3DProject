using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour, IEventTrigger
{
    public bool HasBeenTriggered { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        HasBeenTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (HasBeenTriggered == false)
        {
            HasBeenTriggered = true;
        }
    }
}
