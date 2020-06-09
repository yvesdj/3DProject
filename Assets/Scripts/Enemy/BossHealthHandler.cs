using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BossHealthHandler : MonoBehaviour, IHealthHandler
{
    public SimpleHealthBar healthBar;
    public Enemy enemy;

    public float CurrentHealth { get; set; }
    public float MaxHealth { get { return enemy.maxHealth; } set { MaxHealth = value;  } }

    void Start()
    {
        enemy = GetComponent<Enemy>();
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        CurrentHealth -= amount;

        if(healthBar != null)
        {
            healthBar.UpdateBar(CurrentHealth, MaxHealth);
        }

        if(CurrentHealth <= 0f)
        {
            AddScore();
            Die();
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
        FindObjectOfType<GameManager>().WinGame();
    }
}
