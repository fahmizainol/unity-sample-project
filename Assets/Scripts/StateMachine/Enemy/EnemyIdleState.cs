using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyIdleState : IBaseState
{
    public void Enter(Animator animator)
    {
        //Debug.Log("EnemyIdlestate enter");
        animator.Play("knight_idle");
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }

   public IBaseState Update(PlayerInput input, Rigidbody2D rb)
    {
        throw new NotImplementedException();
    }
}