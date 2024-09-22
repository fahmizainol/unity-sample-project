
public class IdleState : IBaseState
{

    private Player _player;
    // IDEA: Give a isGrounded property to States
    public IdleState(Player player)
    {
        _player = player;
    }

    public void Enter()
    {
        _player.Anim.Play("player_idle");
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
