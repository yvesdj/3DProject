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

    //public Transform playerBody;
    private bool _isCrouching;

    private void Awake()
    {
        c_standardHeight = player.controller.height;

        _playerDimensions = player.playerBody.transform.localScale;
        p_standardHeight = _playerDimensions.y;
        p_crouchHeight = p_standardHeight / 2;

        _collisionDetectorPosition = player.collisionHandler.groundCheck.transform.localPosition;

        _playerCameraPosition = player.playerCamera.transform.localPosition;
        p_cameraHeight = _playerCameraPosition.y;

        print(p_standardHeight);
        print(p_crouchHeight);
        print(player.playerBody);
    }

    public void CheckCrouch()
    {
        print(_playerDimensions);
        //input
        if (Input.GetKeyDown(KeyCode.C))
        {
            _isCrouching = !_isCrouching;
        }

        print(_isCrouching);

        DoCrouch();
    }

    private void DoCrouch()
    {
        if (_isCrouching)
        {
            Crouch();
        }
        else
        {
            Uncrouch();
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

    //public Vector3 ChangeHeight(Vector3 v, float y)
    //{
    //    return new Vector3(v.x, y, v.z);
    //}

}