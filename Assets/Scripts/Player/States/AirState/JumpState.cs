
using UnityEngine;

public class JumpState : AirState
{



    public JumpState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.RB.velocity = new Vector2(Player.RB.velocity.x, Player.Speed);

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
}
