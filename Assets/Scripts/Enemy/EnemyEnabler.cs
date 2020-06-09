using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnabler : MonoBehaviour
{
    private EnemyGunHandler _gunHandler;

    public EnemyTrigger eventTrigger;
    public float duration = 3f;
    public bool HasBeenTriggered { get; set; }

    void Awake()
    {
        _gunHandler = GetComponentInChildren<EnemyGunHandler>();
    }
    
    void Start()
    {
        _gunHandler.isActive = false;
        HasBeenTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTriggers();
    }

    private void CheckTriggers()
    {
        if (eventTrigger.HasBeenTriggered && !HasBeenTriggered)
        {
            HasBeenTriggered = true;
            _gunHandler.isActive = true;
            StartCoroutine(DeactivateEnemyAfterTime());
        }
    }

    IEnumerator DeactivateEnemyAfterTime()
    {
        
        yield return new WaitForSeconds(duration);
        
        _gunHandler.isActive = false;
        
        Debug.Log("Disable");

        Debug.Log("Enemy Active: " + _gunHandler.isActive);
    }
}
