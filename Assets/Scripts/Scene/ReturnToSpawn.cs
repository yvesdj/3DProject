﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToSpawn : MonoBehaviour
{
    public GameObject player;
    public Transform respawnPoint;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Respawn();
        } 
    }

    private void Respawn()
    {
        SoundEffectPicker soundEffectPicker = FindObjectOfType<SoundEffectPicker>();
        soundEffectPicker.PlayRandomDie();
        player.transform.position = respawnPoint.transform.position;
        player.GetComponent<PlayerHealthHandler>().ResetHealth();
    }
}
