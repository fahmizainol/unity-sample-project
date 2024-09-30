
using UnityEngine;

public class IdleState : GroundedState
{
    // IDEA: Give a isGrounded property to States
    public IdleState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.RB.velocity = new Vector2(0, 0);
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
    }
}
