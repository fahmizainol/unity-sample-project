using UnityEngine;

public class PlayerStateMachine
{
    public enum PlayerStates
    {
        Idle,
        Walk,
        Run,
        Attack,
        Jump,
        Rise,
        Fall,
    }

    public IBaseState currentState { get; set; }
    public IdleState IdleState { get; set; }
    public MoveState MoveState { get; set; }
    public JumpState JumpState { get; set; }


    public Player _player;

    public PlayerStateMachine(Player player)
    {
        _player = player;
    }

    public void Init()
    {
        IdleState = new IdleState(_player, this);
        MoveState = new MoveState(_player, this);
        JumpState = new JumpState(_player, this);
        currentState = IdleState;
    }

    public void Start()
    {
        currentState.Enter();

    }

    public void Update()
    {
        currentState.Update();
    }

    public void SwitchState(IBaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }


}