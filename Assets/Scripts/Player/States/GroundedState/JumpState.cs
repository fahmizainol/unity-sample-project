
using UnityEngine;

public class JumpState : GroundedState
{



    public JumpState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
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

        Player.RB.velocity = new Vector2(Player.RB.velocity.x, Player.Speed);

    }

    public void Transition()
    {
    }
}
