using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public Player player;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float groundCheckYPos;

    public bool isGrounded;

    void Start()
    {
        groundCheckYPos = groundCheck.transform.localPosition.y;
    }

    public void CheckCollission()
    {
        isGrounded = CheckGrounded();

        if (isGrounded && player.velocity.y < 0)
        {
            player.velocity.y = -2f;
            player.isJumping = false;
        }
    }

    private bool CheckGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
