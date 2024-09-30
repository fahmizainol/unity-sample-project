
using UnityEngine;

public class FallState : AirState
{



    public FallState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
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
    }
}
