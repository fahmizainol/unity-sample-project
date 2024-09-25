public class GroundedState : PlayerState
{
    public GroundedState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (Player.moveVector.x != 0 && !Player.jump)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.MoveState);
        }
        else if (Player.moveVector.x != 0 && Player.jump)

        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.JumpState);
        }
        else if (Player.jump)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.JumpState);
        }
        else
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.IdleState);
        }

    }
}