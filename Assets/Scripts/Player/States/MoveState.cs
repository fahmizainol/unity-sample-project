
public class MoveState : IBaseState
{

    private Player _player;
    public MoveState(Player player)
    {
        _player = player;
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
        // Q: How would this class know about the current input
    }

    public void Transition()
    {
    }
}
