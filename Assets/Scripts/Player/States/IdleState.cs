
public class IdleState : IBaseState
{

    private Player _player;
    private PlayerStateMachine _stateMachine;
    // IDEA: Give a isGrounded property to States
    public IdleState(Player player, PlayerStateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _player.Anim.Play("player_idle");
    }

    public void Exit()
    {
    }

    public void Update()
    {
        if (_player.moveVector.x != 0)
        {
            _stateMachine.SwitchState(_stateMachine.MoveState);
        }

        if (_player.jump)
        {
            _stateMachine.SwitchState(_stateMachine.JumpState);
        }
    }

    public void Transition()
    {
    }
}
