using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerAnimator : DefaultAnimator
{
    [SerializeField] private string _isMovingAnimatorBool;

    [FormerlySerializedAs("_isAttackingAnimatorBool")] [SerializeField]
    private string _isAttackingAnimatorTrigger;

    public void Move()
    {
        SetAnimatorBool(_isMovingAnimatorBool, true);
    }

    public void Attack()
    {
        SetAnimatorTrigger(_isAttackingAnimatorTrigger);
    }

    public void Idle()
    {
        DisableAllAnimations();
    }

    public override void DisableAllAnimations()
    {
        SetAnimatorBool(_isMovingAnimatorBool, false);
    }
}