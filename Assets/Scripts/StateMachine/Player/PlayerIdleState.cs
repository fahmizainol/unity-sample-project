using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdleState : IBaseState
{
    public void Enter(Animator animator)
    {
        //Debug.Log("EnemyIdlestate enter");
        animator.Play("player_idle");
    }

    public void Exit()
    {
        throw new NotImplementedException();
    }

    public IBaseState Update(PlayerInput input, Rigidbody2D rb)
    {
        Vector2 moveInput = input.actions["Move"].ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
        {
            Debug.Log("Move input detected: " + moveInput);
            // Transition to move state
            return new PlayerWalkState();
        }
        return null;

    }
}