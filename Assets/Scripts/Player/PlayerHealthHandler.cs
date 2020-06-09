using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour, IHealthHandler
{
    public SimpleHealthBar healthBar;
    public Player player;
    public SoundEffectPicker soundEffectPicker;
    public Transform respawnPoint;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get { return player.maxHealth; } set { MaxHealth = value; } }

    void Start()
    {
        player = GetComponent<Player>();
        soundEffectPicker = GetComponent<SoundEffectPicker>();
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //HealthPickups?
    }

    public void TakeDamage(float amount)
    {
        soundEffectPicker.PlayRandomHit();
        CurrentHealth -= amount;
        healthBar.UpdateBar(CurrentHealth, MaxHealth);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    { 
        soundEffectPicker.PlayRandomDie();
        FindObjectOfType<GameManager>().EndGame();
        //player.transform.position = respawnPoint.transform.position;
        //ResetHealth();
    }

    public void ResetHealth()
    {
        CurrentHealth = MaxHealth;
        healthBar.UpdateBar(CurrentHealth, MaxHealth);
    }
}
