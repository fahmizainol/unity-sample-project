using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerStateManager: MonoBehaviour
{
    public enum PlayerStates
    {
        idle,
        run,
        walk,
        jump, 
        attack
    }


    static PlayerIdleState idleState;
    static PlayerRunState runState;
    static PlayerWalkState walkState;
    static PlayerJumpState jumpState;
    static PlayerAttackState attackState;

    protected Animator animator;
    protected IBaseState CurrentState;
    protected PlayerInput input;
    protected Rigidbody2D rb;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        idleState = new PlayerIdleState();
        runState = new PlayerRunState();
        walkState = new PlayerWalkState();
        jumpState = new PlayerJumpState();
        attackState = new PlayerAttackState();

        input = GetComponent<PlayerInput>();


        CurrentState = idleState;
        Debug.Log("awake");
    }
    void Start()
    {
        CurrentState.Enter(animator);
    }

    void Update()
    {
        IBaseState newState = CurrentState.Update(input, rb);
        if (newState == null){
            return;
        }
        CurrentState = newState;
        CurrentState.Enter(animator);
        // Debug.Log(input.actions);
    }

}
