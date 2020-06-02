using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour, IHealthHandler
{
    public float Health { get; set; }

    // Update is called once per frame
    void Update()
    {
        //HealthPickups?
    }

    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You die now");
    }
}
