using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody))]
public class MoveComponent : MonoBehaviour, IMove
{
    [SerializeField] private float _characterMovementSpeed;
    [SerializeField] private float _characterRotationSpeed;
    [Space]
    [Header("Information:")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _smoothTime = 0.05f;
    private Rigidbody _rigidbody;
    private float _currentVelocity;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector2 movementDirection)
    {
        _movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0f, 1f);
        _rigidbody.velocity = new Vector3(
            movementDirection.x, 0, movementDirection.y) * _movementSpeed * _characterMovementSpeed;
        if (movementDirection != Vector2.zero)
        {
            var targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.y) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, _smoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
