
public class JumpState : IBaseState
{

    private Player _player;
    public JumpState(Player player)
    {
        _player = player;
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

    }

    public void Transition()
    {
    }
}
