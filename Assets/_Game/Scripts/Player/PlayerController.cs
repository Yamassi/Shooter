using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IHealth _health;
    private IInput _input;
    private IMove _move;
    private IAnimate _animate;
    private void Awake()
    {
        _health = GetComponent<IHealth>();
        _input = GetComponent<IInput>();
        _move = GetComponent<IMove>();
        _animate = GetComponent<IAnimate>();
    }
    private void FixedUpdate()
    {
        _move.Move(_input.GetInput());
        _animate.SetMovementDirection(_input.GetInput());
    }
}
