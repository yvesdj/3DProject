using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }

    public bool IsEnabled { get; set; }

    public bool IsCrouching { get; set; }
    public bool IsJumping { get; set; }
    public bool IsFiring { get; set; }
    public bool IsSprinting { get; set; }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        if (IsEnabled)
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vertical = Input.GetAxis("Vertical");

            IsCrouching = Input.GetKeyDown(KeyCode.C);
            IsJumping = Input.GetButtonDown("Jump");
            IsFiring = Input.GetButton("Fire1");
            IsSprinting = Input.GetKey(KeyCode.LeftShift);
        }
        
    }
}
