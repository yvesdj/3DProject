using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    private RecoilHandler _recoilHandler;

    private float _mouseX;
    private float _mouseY;

    private float _xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _recoilHandler = GetComponent<RecoilHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = _recoilHandler.sideRecoil + Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        _mouseY = _recoilHandler.upwardsRecoil + Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _recoilHandler.ResetRecoil();

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * _mouseX);
    }
}
