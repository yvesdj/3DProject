using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour, IHealthHandler
{
    public SimpleHealthBar healthBar;
    public Enemy enemy;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get { return enemy.maxHealth; } set { MaxHealth = value; } }


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();
        CurrentHealth = MaxHealth;
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;
        if (healthBar != null)
        {
            healthBar.UpdateBar(CurrentHealth, MaxHealth);
        }
        
        if (CurrentHealth <= 0f)
        {
            AddScore();
            PlaySound();

            Die();
        }
    }

    private static void PlaySound()
    {
        SoundEffectPicker soundEffectPicker = FindObjectOfType<SoundEffectPicker>();
        if (soundEffectPicker != null)
        {
            soundEffectPicker.PlayRandomZinger();
        }
    }

    private void AddScore()
    {
        ScoreHandler scoreHandler = FindObjectOfType<ScoreHandler>();
        scoreHandler.AddScore(enemy.scoreAmount);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
