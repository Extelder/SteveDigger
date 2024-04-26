using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAnimationState : State
{
    [SerializeField] private PlayerAnimator _animator;
    
    public override void Enter()
    {
        _animator.Idle();   
    }
}
