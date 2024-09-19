using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunState : IBaseState
{

    public void Enter(Animator animator)
    {
        //throw new NotImplementedException();
        animator.Play("player_run");
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