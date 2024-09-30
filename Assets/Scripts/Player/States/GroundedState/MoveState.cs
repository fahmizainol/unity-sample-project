using UnityEngine;
public class MoveState : GroundedState
{
    public MoveState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
    {
    }


    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        base.Update();


    }

    public void Transition()
    {
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Player.RB.velocity = new Vector2(Player.moveVector.x * Player.Speed, Player.RB.velocity.y);
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
