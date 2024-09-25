
using UnityEngine;

public class JumpState : IBaseState
{

    private Player _player;
    private PlayerStateMachine _stateMachine;

    public JumpState(Player player, PlayerStateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _player.Anim.Play("player_jump");
    }

    public void Exit()
    {
    }

    public void Update()
    {
        _player.RB.velocity = new Vector2(_player.RB.velocity.x, _player.Speed);
        if (!_player.jump)
        {
            _stateMachine.SwitchState(_stateMachine.IdleState);
        }
    }

    public void Transition()
    {
    }
}
