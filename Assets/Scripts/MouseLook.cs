using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    private float _xRotation = 0f;

    private float _sideRecoil;
    private float _upwardsRecoil;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //recoil needs solid
        float mouseX = _sideRecoil + Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = _upwardsRecoil + Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _sideRecoil = 0;
        _upwardsRecoil = 0;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void RecoilBack(float up, float side)
    {
        _upwardsRecoil += up;
        _sideRecoil += side;
    }
}
