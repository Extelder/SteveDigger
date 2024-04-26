using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;

    [SerializeField] private State _moveAnimationState;
    [SerializeField] private State _idleAnimationState;
    [SerializeField] private State _attackAnimationState;

    private StateMachine _stateMachine;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Init(_idleAnimationState);
    }

    private void Update()
    {
        if (_movement.Direction.sqrMagnitude > 0.1)
        {
            Move();
            return;
        }

        Idle();
    }

    public void Move()
    {
        _stateMachine.ChangeState(_moveAnimationState);
    }

    public void Attack()
    {
        _stateMachine.ChangeState(_attackAnimationState);
    }

    public void Idle()
    {
        _stateMachine.ChangeState(_idleAnimationState);
    }
}