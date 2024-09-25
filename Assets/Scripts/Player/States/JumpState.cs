
using UnityEngine;

public class JumpState : PlayerState
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
        Player.RB.velocity = new Vector2(Player.RB.velocity.x, Player.Speed);
        if (!Player.jump)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.IdleState);
        }
    }

    public void Transition()
    {
    }
}
