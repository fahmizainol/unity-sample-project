
using UnityEngine;

public class AttackState : GroundedState
{
    // IDEA: Give a isGrounded property to States
    public AttackState(Player player, PlayerStateMachine stateMachine, int animationHash) : base(player, stateMachine, animationHash)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.RB.velocity = new Vector2(0, 0);
        Debug.Log("Attack Enter");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        base.Update();
        // attackStartTime += Time.deltaTime;
        Debug.Log(Player.attackStartTime);

        if (Time.time - Player.attackStartTime >= Player.attackDuration)
        {
            Debug.Log("attack end");
            Player.attack = false;
        }
    }

    public void Transition()
    {
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
