using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour, IHealthHandler
{
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
        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
