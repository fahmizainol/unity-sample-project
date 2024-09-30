using UnityEngine;
public class AirState : PlayerState
{
    public AirState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (!Player.IsGrounded)
        {
            // if (Player.moveVector.x != 0)
            // {
            //     // Player.RB.velocity = new Vector2(Player.moveVector.x * Player.Speed, Player.RB.velocity.y);
            //     PlayerStateMachine.SwitchState(PlayerStateMachine.AirMoveState);

            // }
            if (Player.RB.velocity.y < 0)
            {
                // Player.Anim.Play("player_falling");
                PlayerStateMachine.SwitchState(PlayerStateMachine.FallState);
            }
            if (Player.RB.velocity.y > 0)
            {
                PlayerStateMachine.SwitchState(PlayerStateMachine.RiseState);
            }
        }
        else if (Player.IsGrounded && Player.RB.velocity.y < 0.01f)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.IdleState);
            // Player.jump = false;
        }


    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (Player.moveVector.x != 0)
        {
            Debug.Log($"MoveVector in Air: {Player.moveVector.x}");
            Player.RB.velocity = new Vector2(Player.moveVector.x * Player.Speed, Player.RB.velocity.y);
        }
        if (!Player.jump)
        {
            Player.RB.AddForce(Physics2D.gravity * Player.RB.mass);
        }
        SetFacingDirection();
    }

    private void SetFacingDirection()
    {
        if (Player.moveVector.x > 0)
        {
            Player.transform.localScale = new Vector2(1, 1);
        }
        else if (Player.moveVector.x < 0)
        {
            Player.transform.localScale = new Vector2(-1, 1);
        }
    }
}