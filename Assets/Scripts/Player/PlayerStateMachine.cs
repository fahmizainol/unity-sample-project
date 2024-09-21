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

    public PlayerStates currentState { get; set; }

    public void SwitchState(PlayerStates newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case PlayerStates.Idle:
                break;
            case PlayerStates.Walk:
                break;
            case PlayerStates.Run:
                break;
            case PlayerStates.Attack:
                break;
            case PlayerStates.Jump:
                break;
        }
    }


}