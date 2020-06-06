using UnityEngine;

public interface IEventTrigger
{
    bool hasBeenTriggered { get; set; }
    void OnTriggerEnter(Collider other);
}