using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationState : State
{
    [SerializeField] private PlayerAnimator _animator;

    public override void Enter()
    {
        _animator.Attack();
    }
}