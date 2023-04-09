using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveComponent : MonoBehaviour, IMove
{
    [SerializeField] private float _characterMovementSpeed;
    [SerializeField] private float _movementSpeed;
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    public void Move(Vector2 movementDirection)
    {
        _movementSpeed = Mathf.Clamp(movementDirection.magnitude, 0f, 1f);
        _rigidbody.velocity = new Vector3(movementDirection.x, 0, movementDirection.y) * _movementSpeed * _characterMovementSpeed;
    }
}
