using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToSpawn : MonoBehaviour
{
    public Player player;
    public Transform respawnPoint;

    public void OnTriggerEnter(Collider other)
    {
        Respawn();
    }

    private void Respawn()
    {
        player.transform.position = respawnPoint.transform.position;
        player.GetComponent<PlayerHealthHandler>().ResetHealth();
    }
}
