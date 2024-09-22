using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
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


    private Player _player;

    public PlayerStateMachine(Player player)
    {
        _player = player;
    }

    private void Awake()
    {
        IdleState = new IdleState(_player);
        MoveState = new MoveState(_player);
        JumpState = new JumpState(_player);
        currentState = IdleState;
    }

    private void Start()
    {
        currentState.Enter();

    }

    private void Update()
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