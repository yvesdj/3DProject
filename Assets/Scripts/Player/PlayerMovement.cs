using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private CharacterController _controller;

    private Vector3 _currentVelocity;
    public float maxSpeed = 15f;

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        //Horizontal = Input.GetAxis("Horizontal");
        //Vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * _playerInput.Horizontal + transform.forward * _playerInput.Vertical;
        _currentVelocity = _controller.velocity;

        _controller.Move(move * maxSpeed * Time.deltaTime);
    }
}
