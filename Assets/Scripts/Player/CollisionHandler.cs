using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private PlayerMovement _playerMovement;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float groundCheckYPos;

    public bool isGrounded;

    void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    void Start()
    {
        groundCheckYPos = groundCheck.transform.localPosition.y;
    }

    public void CheckCollission()
    {
        isGrounded = CheckGrounded();

        if (isGrounded && _playerMovement.currentVelocity.y < 0)
        {
            _playerMovement.currentVelocity.y = -2f;
            _playerMovement.isJumping = false;
        }

        Debug.Log(isGrounded);
    }

    private bool CheckGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }
}
