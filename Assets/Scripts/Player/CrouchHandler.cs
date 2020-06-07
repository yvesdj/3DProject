using Assets.Scripts;
using UnityEngine;

public class CrouchHandler : MonoBehaviour
{
    private Player _player;
    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput;

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

    private bool _isCrouching;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _player = GetComponent<Player>();
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        c_standardHeight = _playerMovement.Controller.height;

        _playerDimensions = _player.playerBody.transform.localScale;
        p_standardHeight = _playerDimensions.y;
        p_standardSpeed = _playerMovement.maxSpeed;
        p_crouchSpeed = p_standardSpeed / 2;
        p_crouchHeight = p_standardHeight / 2;

        _collisionDetectorPosition = _playerMovement.CollisionHandler.groundCheck.transform.localPosition;

        _playerCameraPosition = _player.playerCamera.transform.localPosition;
        p_cameraHeight = _playerCameraPosition.y;
    }

    public void CheckCrouch()
    {
        if (_playerInput.IsCrouching)
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
            _playerMovement.maxSpeed = p_crouchSpeed;
        }
        else
        {
            Uncrouch();
            _playerMovement.maxSpeed = p_standardSpeed;
        }
    }

    private void Uncrouch()
    {
        _playerMovement.Controller.height = c_standardHeight;
        _player.playerBody.transform.localScale = Utils.ChangeYFromVector3(_playerDimensions, p_standardHeight);

        _playerMovement.CollisionHandler.groundCheck.transform.localPosition = Utils.ChangeYFromVector3(_collisionDetectorPosition, _playerMovement.CollisionHandler.groundCheckYPos);

        _player.playerCamera.transform.localPosition = Utils.ChangeYFromVector3(_player.playerCamera.transform.localPosition, p_cameraHeight);
    }

    private void Crouch()
    {
        _playerMovement.Controller.height = c_crouchHeight;
        _player.playerBody.transform.localScale = Utils.ChangeYFromVector3(_playerDimensions, p_crouchHeight);

        _playerMovement.CollisionHandler.groundCheck.transform.localPosition = Utils.ChangeYFromVector3(_collisionDetectorPosition, _playerMovement.CollisionHandler.groundCheckYPos / 2);

        _player.playerCamera.transform.localPosition = Utils.ChangeYFromVector3(_player.playerCamera.transform.localPosition, 0.5f);

    }
}