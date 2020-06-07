using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour, IPickup
{
    public float healingAmount;

    public void EnhancePlayer(Collider player)
    {
        PlayerHealthHandler playerHealth = player.GetComponent<PlayerHealthHandler>();
        playerHealth.CurrentHealth += healingAmount;
        if (playerHealth.CurrentHealth > playerHealth.MaxHealth)
        {
            playerHealth.CurrentHealth = playerHealth.MaxHealth;
        }
        playerHealth.healthBar.UpdateBar(playerHealth.CurrentHealth, playerHealth.MaxHealth);
    }
}
