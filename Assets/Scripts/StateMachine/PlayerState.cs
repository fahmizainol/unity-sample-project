// NOTE: Basically acts as parent/base class that all states inherit from to not write the same thing
public class PlayerState
{
    protected Player Player;
    protected PlayerStateMachine PlayerStateMachine;
    protected int AnimationHash;

    public PlayerState(Player player, PlayerStateMachine stateMachine, int animationHash)
    {
        Player = player;
        PlayerStateMachine = stateMachine;
        AnimationHash = animationHash;
    }

    public virtual void Enter()
    {
        Player.Anim.Play(AnimationHash);
    }

    public virtual void Exit() { }

    public virtual void Update()
    {

    }




}