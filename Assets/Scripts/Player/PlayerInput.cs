using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        //Vector3 move = transform.right * x + transform.forward * z;
        //currentVelocity = controller.velocity;

        //controller.Move(move * maxSpeed * Time.deltaTime);
    }
}
