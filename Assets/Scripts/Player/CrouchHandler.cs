using Assets.Scripts;
using UnityEngine;

public class CrouchHandler : MonoBehaviour
{
    public Player player;
    private Vector3 _playerDimensions;
    private Vector3 _collisionDetectorPosition;
    private Vector3 _playerCameraPosition;

    private float p_cameraHeight;

    private float c_standardHeight;
    private float c_crouchHeight = 0.5f;

    private float p_standardHeight;
    private float p_crouchHeight;
    private float p_standardSpeed;
    private float p_crouchSpeed;

    //public Transform playerBody;
    private bool _isCrouching;

    private void Awake()
    {
        c_standardHeight = player.controller.height;

        _playerDimensions = player.playerBody.transform.localScale;
        p_standardHeight = _playerDimensions.y;
        p_standardSpeed = player.maxSpeed;
        p_crouchSpeed = p_standardSpeed / 2;
        p_crouchHeight = p_standardHeight / 2;

        _collisionDetectorPosition = player.collisionHandler.groundCheck.transform.localPosition;

        _playerCameraPosition = player.playerCamera.transform.localPosition;
        p_cameraHeight = _playerCameraPosition.y;
    }

    public void CheckCrouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            _isCrouching = !_isCrouching;
        }

        DoCrouch();
    }

    private void DoCrouch()
    {
        if (_isCrouching)
        {
            Crouch();
            player.maxSpeed = p_crouchSpeed;
        }
        else
        {
            Uncrouch();
            player.maxSpeed = p_standardSpeed;
        }
    }

    private void Uncrouch()
    {
        player.controller.height = c_standardHeight;
        player.playerBody.transform.localScale = Utils.ChangeYFromVector3(_playerDimensions, p_standardHeight);

        player.collisionHandler.groundCheck.transform.localPosition = Utils.ChangeYFromVector3(_collisionDetectorPosition, player.collisionHandler.groundCheckYPos);

        player.playerCamera.transform.localPosition = Utils.ChangeYFromVector3(player.playerCamera.transform.localPosition, p_cameraHeight);
    }

    private void Crouch()
    {
        player.controller.height = c_crouchHeight;
        player.playerBody.transform.localScale = Utils.ChangeYFromVector3(_playerDimensions, p_crouchHeight);

        player.collisionHandler.groundCheck.transform.localPosition = Utils.ChangeYFromVector3(_collisionDetectorPosition, player.collisionHandler.groundCheckYPos / 2);

        player.playerCamera.transform.localPosition = Utils.ChangeYFromVector3(player.playerCamera.transform.localPosition, 0.5f);

    }
}