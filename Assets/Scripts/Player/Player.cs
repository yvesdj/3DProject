using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public IHealthHandler healthHandler;
    public float maxHealth;

    //Jump uses this controller, jump needs to move to playermovement
    public CharacterController controller;
    public CrouchHandler crouchHandler;
    public CollisionHandler collisionHandler;

    public Transform playerBody;
    public Transform playerCamera;

    //CrouchHandler uses this, needs refactor to use from playermovemnt
    public float maxSpeed = 15f;

    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    
    
    public Vector3 velocity;

    //public Vector3 currentVelocity;
    public bool isJumping;

    private void Awake()
    {
        //healthHandler = GetComponent<IHealthHandler>();
        //healthHandler.CurrentHealth = maxHealth;

        collisionHandler = GetComponent<CollisionHandler>();
        crouchHandler = GetComponent<CrouchHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        collisionHandler.CheckCollission();

        //Movement();

        Jump();

        crouchHandler.CheckCrouch();
    }

    //public void Movement()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    Vector3 move = transform.right * x + transform.forward * z;
    //    currentVelocity = controller.velocity;
 
    //    controller.Move(move * maxSpeed * Time.deltaTime);
    //}

    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && collisionHandler.isGrounded && !isJumping)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            isJumping = true;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
