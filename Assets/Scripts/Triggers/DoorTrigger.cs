using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            animator.SetBool("OpenDoor", true);
        }
    }
}
