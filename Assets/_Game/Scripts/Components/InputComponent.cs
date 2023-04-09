using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputComponent : MonoBehaviour, IInput
{
    [SerializeField] private Vector2 _movementDirection;
    private PlayerInput _playerInput;
    public Vector2 GetInput()
    {
#if UNITY_EDITOR
        Keyboard();
#endif
#if UNITY_ANDROID && !UNITY_EDITOR || UNITY_IOS && !UNITY_EDITOR
        Touch();
#endif
        return _movementDirection;
    }
    private void Keyboard()
    {
        _movementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _movementDirection.Normalize();
    }
    private void Touch()
    {
        _movementDirection = _playerInput.actions["Move"].ReadValue<Vector3>();
        _movementDirection.Normalize();
    }
}
