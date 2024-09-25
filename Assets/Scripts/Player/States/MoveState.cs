using UnityEngine;
public class MoveState : IBaseState
{

    private Player _player;
    private PlayerStateMachine _stateMachine;


    public MoveState(Player player, PlayerStateMachine stateMachine)
    {
        _player = player;
        _stateMachine = stateMachine;
    }

    public void Enter()
    {
        _player.Anim.Play("player_walk");
    }

    public void Exit()
    {
    }

    public void Update()
    {
        _player.RB.velocity = new Vector2(_player.moveVector.x * _player.Speed, _player.RB.velocity.y);
        SetFacingDirection(_player.moveVector);
        if (_player.moveVector.x == 0)
        {
            _stateMachine.SwitchState(_stateMachine.IdleState);
        }
    }

    public void Transition()
    {
    }

    private void SetFacingDirection(Vector2 inputVector)
    {
        if (_player.moveVector.x > 0)
        {
            _player.transform.localScale = new Vector2(1, 1);
        }
        else if (_player.moveVector.x < 0)
        {
            _player.transform.localScale = new Vector2(-1, 1);
        }
    }
}
