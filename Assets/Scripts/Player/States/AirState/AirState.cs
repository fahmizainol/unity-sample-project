public class AirState : PlayerState
{
    public AirState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
        if (Player.RB.velocity.y < 0)
        {
            // Player.Anim.Play("player_falling");
            PlayerStateMachine.SwitchState(PlayerStateMachine.FallState);
        }
        else if (Player.RB.velocity.y > 0)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.RiseState);
        }
        else if (Player.moveVector.x == 0)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.IdleState);
        }
        else if (Player.moveVector.x != 0)
        {
            PlayerStateMachine.SwitchState(PlayerStateMachine.AirMoveState);
        }

    }
}