
using UnityEngine;

public class AirMoveState : AirState
{



    public AirMoveState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
    {
    }

    public override void Enter()
    {

    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        base.Update();
        Player.RB.velocity = new Vector2(Player.moveVector.x * Player.Speed, Player.RB.velocity.y);

    }

    public void Transition()
    {
    }
}
