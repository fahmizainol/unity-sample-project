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
        Player.RB.velocity = new Vector2(Player.moveVector.x * Player.Speed, Player.RB.velocity.y);
        // SetFacingDirection();

    }

    public void Transition()
    {
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
