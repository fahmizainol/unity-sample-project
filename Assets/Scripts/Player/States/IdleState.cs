
public class IdleState : PlayerState
{
    // IDEA: Give a isGrounded property to States
    public IdleState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
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
        if (Player.moveVector.x != 0)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.MoveState);
        }

        if (Player.jump)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.JumpState);
        }
    }

    public void Transition()
    {
    }
}
