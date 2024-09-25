using UnityEngine;
public class MoveState : PlayerState
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
        Player.RB.velocity = new Vector2(Player.moveVector.x * Player.Speed, Player.RB.velocity.y);
        SetFacingDirection(Player.moveVector);
        if (Player.moveVector.x == 0)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.IdleState);
        }
    }

    public void Transition()
    {
    }

    private void SetFacingDirection(Vector2 inputVector)
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
