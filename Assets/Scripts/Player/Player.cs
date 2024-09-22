using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;

    public Vector2 _inputVector;
    private PlayerStateMachine _stateMachine;

    public float Speed = 10f;

    public Rigidbody2D RB;
    public Animator Anim;

    void Awake()
    {
        Debug.Log("player awake");
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        _stateMachine = new PlayerStateMachine(this);

        _inputReader.EnablePlayerInput();
    }

    void Start()
    {
        _inputReader.MoveEvent += HandleMove;
        _inputReader.JumpEvent += HandleJump;
    }



    void Update()
    {
        // inputReader.MoveEvent += OnMove;

        // NOTE: the reason this needs to be put on Update is because
        // Update is ran once every frame so as long as the User is holding the
        // movement button, the velocity will be the same. Once the user
        // releases the button the velocity will be 0.
        // E.g: Frame 1 - 5: User press W, RB.velocity = 5m/s
        // Frame 6: User releases W, RB.Velocity = 0m/s
        RB.velocity = new Vector2(_inputVector.x * Speed, RB.velocity.y);

    }

    private void SetFacingDirection(Vector2 inputVector)
    {
        if (_inputVector.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (_inputVector.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    // EVENT LISTENERS 
    // NOTE: will be called as a callback which is then used to set the property of this 
    // Player class to the argument
    private void HandleMove(Vector2 inputVector)
    {

        // NOTE: If we tie the SwitchState here, it will be prone to bugs
        // E.g: When player is in the air, it can duck, run unless we do some condition
        // checking here like if _stateMachine != JumpState, etc which kinda defeats
        // the purpose of doing FSM in the first place
        // _stateMachine.SwitchState(_stateMachine.MoveState); // Will trigger the Update()

        _inputVector = inputVector;
        SetFacingDirection(_inputVector);
    }

    private void HandleJump()
    {
        _stateMachine.SwitchState(_stateMachine.JumpState);
    }

}

// T: If the state is tied to the input, 
