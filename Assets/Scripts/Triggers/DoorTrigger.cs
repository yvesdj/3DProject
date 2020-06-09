﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    GameObject door;

    public bool isOpened = false;

    private void OnTriggerEnter(Collider col)
    {
        if (!isOpened)
        {
            door.transform.position += new Vector3(0, -6, 0);
            isOpened = true;
        }
    }
}
