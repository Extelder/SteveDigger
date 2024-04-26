using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimationState : State
{
    [SerializeField] private PlayerAnimator _animator;

    public override void Enter()
    {
       _animator.Move();   
    }
}
