using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float Horizontal { get; set; }
    public float Vertical { get; set; }

    public bool IsCrouching { get; set; }
    public bool IsJumping { get; set; }

    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    public void GetInput()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        IsCrouching = Input.GetKeyDown(KeyCode.C);
        IsJumping = Input.GetButtonDown("Jump");
    }
}
