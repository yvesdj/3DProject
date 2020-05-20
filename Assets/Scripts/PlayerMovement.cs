using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private float c_standardHeight;
    private float c_crouchHeight = 0.5f;

    public float maxSpeed = 20f;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private float _gCYPos;

    private Vector3 _velocity;
    private bool _isGrounded;

    public Vector3 currentVelocity;
    private bool _isJumping = false;

    private bool _isCrouching;
    public Transform playerBody;
    private float p_standardHeight;

    // Start is called before the first frame update
    void Start()
    {
        c_standardHeight = controller.height;

        Vector3 playerDimensions = playerBody.transform.localScale;
        p_standardHeight = playerDimensions.y;

        _gCYPos = groundCheck.transform.localPosition.y;

        print(playerDimensions);
        print(p_standardHeight);
    }

    // Update is called once per frame
    void Update()
    {
        CheckCollission();

        Movement();

        Jump();

        Crouch();
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
            if (_isCrouching)
            {
                _isCrouching = false;
            } else
            {
                _isCrouching = true;
            }
        }

        

        if (_isCrouching)
        {
            print("Crouch");
            controller.height = c_crouchHeight;

            playerBody.transform.localScale = ChangeHeight(playerBody.transform.localScale, p_standardHeight / 2);

            
            groundCheck.transform.localPosition = ChangeHeight(groundCheck.transform.localPosition, _gCYPos / 2);
        }
        else
        {
            controller.height = c_standardHeight;
            playerBody.transform.localScale = ChangeHeight(playerBody.transform.localScale, p_standardHeight);

            groundCheck.transform.localPosition = ChangeHeight(groundCheck.transform.localPosition, _gCYPos);
        }
    }

    public Vector3 ChangeHeight(Vector3 v, float y)
    {
        return new Vector3(v.x, y, v.z);
    }
}
