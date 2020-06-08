﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInput _playerInput;
    public CrouchHandler _crouchHandler;
    public CharacterController Controller { get; set; }
    public CollisionHandler CollisionHandler { get; set; }
    

    public Vector3 currentVelocity;
    public float normalSpeed = 15f;
    public float sprintSpeed = 20f;

    public Vector3 jumpVelocity;
    public bool isJumping;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _crouchHandler = GetComponent<CrouchHandler>();
        Controller = GetComponent<CharacterController>();
        CollisionHandler = GetComponent<CollisionHandler>();
    }

    private void Update()
    {
        CollisionHandler.CheckCollission();
        _crouchHandler.CheckCrouch();
        Movement();
        Jump();
    }

    public void Move()
    {
        CollisionHandler.CheckCollission();
        _crouchHandler.CheckCrouch();
        Movement();
        Jump();
    }

    public void Movement()
    {
        float speed = normalSpeed;
        Vector3 move = transform.right * _playerInput.Horizontal + transform.forward * _playerInput.Vertical;
        currentVelocity = Controller.velocity;
        if (!_crouchHandler.IsCrouching)
        {
            speed = ChangeSpeed(speed);
        }
        //speed = ChangeSpeed(speed);
        Controller.Move(move * speed * Time.deltaTime);
    }

    private float ChangeSpeed(float speed)
    {
        if (_playerInput.isSprinting)
        {
            speed = sprintSpeed;
        }

        return speed;
    }

    public void Jump()
    {
        if (_playerInput.IsJumping && CollisionHandler.isGrounded && !isJumping)
        {
            jumpVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }

        jumpVelocity.y += gravity * Time.deltaTime;

        Controller.Move(jumpVelocity * Time.deltaTime);
    }
}
