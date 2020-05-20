using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float maxSpeed = 20f;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 _velocity;
    private bool _isGrounded;

    public Vector3 currentVelocity;
    private bool _isJumping = false;

    private bool _isCrouching;
    public Transform playerBody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollission();

        Movement();

        Jump();
    }

    public void CheckCollission()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
            _isJumping = false;
        }
    }

    public void Movement()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        currentVelocity = controller.velocity;
 
        controller.Move(move * maxSpeed * Time.deltaTime);


    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && _isGrounded && !_isJumping)
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            _isJumping = true;
        }

        _velocity.y += gravity * Time.deltaTime;

        controller.Move(_velocity * Time.deltaTime);
    }

    public void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _isCrouching = true;
            print("crouch");
        }
        else
        {
            _isCrouching = false;
        }

        if (_isCrouching)
        {

        }
    }
}
