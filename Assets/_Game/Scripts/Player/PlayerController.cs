using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IHealth _health;
    private IInput _input;
    private IMove _move;
    private IAnimate _animate;
    private IAim _aim;
    private void Awake()
    {
        _health = GetComponent<IHealth>();
        _input = GetComponent<IInput>();
        _move = GetComponent<IMove>();
        _animate = GetComponent<IAnimate>();
        _aim = GetComponent<IAim>();
    }
    private void FixedUpdate()
    {
        _move.Move(_input.GetDirection());
        _animate.SetMovementDirection(_input.GetDirection());
        _aim.SetAim(_input.GetFire());
    }
}
