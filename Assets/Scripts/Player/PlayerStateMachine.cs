using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; set; }
    public IdleState IdleState { get; set; }
    public MoveState MoveState { get; set; }
    public JumpState JumpState { get; set; }
    public FallState FallState { get; set; }
    public RiseState RiseState { get; set; }
    public AirMoveState AirMoveState { get; set; }
    public AttackState AttackState { get; set; }

    public int idleHash = Animator.StringToHash("player_idle");
    public int walkHash = Animator.StringToHash("player_walk");
    public int runHash = Animator.StringToHash("player_run");
    public int attackHash = Animator.StringToHash("player_attack_1");
    public int jumpHash = Animator.StringToHash("player_jump");
    public int riseHash = Animator.StringToHash("player_rising");
    public int fallHash = Animator.StringToHash("player_falling");


    public Player Player;

    public PlayerStateMachine(Player player)
    {
        Player = player;
    }

    public void Init()
    {
        IdleState = new IdleState(Player, this, idleHash);
        MoveState = new MoveState(Player, this, walkHash);
        JumpState = new JumpState(Player, this, jumpHash);
        FallState = new FallState(Player, this, fallHash);
        RiseState = new RiseState(Player, this, riseHash);
        AirMoveState = new AirMoveState(Player, this, jumpHash);
        AttackState = new AttackState(Player, this, attackHash);
        currentState = IdleState;
    }

    public void Start()
    {
        currentState.Enter();

    }

    public void Update()
    {
        // Debug.Log($"Current State: {currentState.ToString()}");
        currentState.Update();
    }


    public void SwitchState(PlayerState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }


}