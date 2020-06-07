using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private CrouchHandler _crouchHandler;
    public CharacterController Controller { get; set; }
    //private CharacterController Controller;
    public CollisionHandler CollisionHandler { get; set; }
    //private CollisionHandler CollisionHandler;

    public Vector3 currentVelocity;
    public float maxSpeed = 15f;

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

    // Update is called once per frame
    void Update()
    {
        CollisionHandler.CheckCollission();
        _crouchHandler.CheckCrouch();
        Movement();
        Jump();
    }

    public void Movement()
    {
        Vector3 move = transform.right * _playerInput.Horizontal + transform.forward * _playerInput.Vertical;
        currentVelocity = Controller.velocity;

        Controller.Move(move * maxSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        if (_playerInput.IsJumping && CollisionHandler.isGrounded && !isJumping)
        {
            currentVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }

        currentVelocity.y += gravity * Time.deltaTime;

        Controller.Move(currentVelocity * Time.deltaTime);
    }
}
