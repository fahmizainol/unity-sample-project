using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;

    public Vector2 moveVector;
    public bool jump;

    public PlayerStateMachine stateMachine;

    public float Speed = 10f;

    public Rigidbody2D RB;
    public Animator Anim;


    void Awake()
    {
        Debug.Log("player awake");
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        stateMachine = new PlayerStateMachine(this);
        stateMachine.Init();

        _inputReader.EnablePlayerInput();
    }

    void Start()
    {
        _inputReader.MoveEvent += (inputVector) => { moveVector = inputVector; };
        _inputReader.JumpEvent += () => { jump = true; };
        _inputReader.JumpEventCancelled += () => { jump = false; };
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
        // RB.velocity = new Vector2(inputVector.x * Speed, RB.velocity.y);

        stateMachine.currentState.Update();

    }


}

// T: If the state is tied to the input, 
