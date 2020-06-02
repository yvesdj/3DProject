using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour, IHealthHandler
{
    public SimpleHealthBar healthBar;
    public Player player;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get { return player.maxHealth; } set { MaxHealth = value; } }

    void Start()
    {
        player = GetComponent<Player>();
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //HealthPickups?
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        healthBar.UpdateBar(CurrentHealth, MaxHealth);
        Debug.Log(CurrentHealth);

        if (CurrentHealth <= 0f)
        {
            

            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You die now");
    }
}
