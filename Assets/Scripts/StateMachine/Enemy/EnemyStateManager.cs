using UnityEngine;


public class EnemyStateManager: MonoBehaviour
{
    public enum EnemyStates
    {
        idle,
        run,
    }


    static EnemyIdleState idleState;
    static EnemyRunState runState;
    protected Animator animator;
    protected IBaseState CurrentState;

    void Awake()
    {
        animator = GetComponent<Animator>();
        idleState = new EnemyIdleState();
        runState = new EnemyRunState();
        CurrentState = runState;
        Debug.Log("awake");
    }
    void Start()
    {
        CurrentState.Enter(animator);
    }

    void Update()
    {
        //CurrentState.Update();
    }

}
