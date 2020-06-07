using UnityEngine;

public interface IEventTrigger
{
    bool HasBeenTriggered { get; set; }
    void OnTriggerEnter(Collider other);
}