
using UnityEngine;

public class RiseState : AirState
{



    public RiseState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
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
}
