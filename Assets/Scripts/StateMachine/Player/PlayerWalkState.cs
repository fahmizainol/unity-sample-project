using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkState : IBaseState
{

    public void Enter(Animator animator)
    {
        //throw new NotImplementedException();
        animator.Play("player_walk");
    }
    // test
    public void Exit()
    {
        throw new NotImplementedException();
    }

   public IBaseState Update(PlayerInput input, Rigidbody2D rb)
    {
        // throw new NotImplementedException();
        Vector2 moveInput = input.actions["Move"].ReadValue<Vector2>();

        Debug.Log("Player walk");
        if (moveInput != Vector2.zero){
            rb.velocity = new Vector2(moveInput.x * 5f, rb.velocity.y);
        }
        else if (moveInput == Vector2.zero)
        {
            Debug.Log("Move input detected: " + moveInput);
            // Transition to move state
            return new PlayerIdleState();
        }
        else if (input.actions["Jump"].triggered){
            return new PlayerJumpState();
        }
        return null;
    }
}