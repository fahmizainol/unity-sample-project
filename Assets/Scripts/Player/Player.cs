using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;

    public Vector2 moveVector;
    public bool jump;
    public bool move;

    public PlayerStateMachine stateMachine;

    // TODO: Refactor these values into PlayerData SO. 
    public float Speed = 10f;
    public LayerMask GroundLayer;
    public float groundCheckDistance = 0.10f;

    public bool IsGrounded { get; set; }

    public Rigidbody2D RB;
    public Animator Anim;
    public CapsuleCollider2D Collider;


    void Awake()
    {
        Debug.Log("player awake");
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Collider = GetComponent<CapsuleCollider2D>();

        GroundLayer = LayerMask.GetMask("Ground");
        stateMachine = new PlayerStateMachine(this);
        stateMachine.Init();

        _inputReader.EnablePlayerInput();
    }

    void Start()
    {
        _inputReader.MoveEvent += (inputVector) => { move = true; moveVector = inputVector; };
        _inputReader.MoveEventCancelled += () => { move = false; };
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

        // if (CheckIsGrounded())
        // {
        //     Debug.Log("grounded");
        // }

        Debug.Log($"Current State: {stateMachine.currentState.ToString()}");

    }

    void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
        Debug.Log($"Velolcity: {RB.velocity}");

    }

    public bool CheckIsGrounded()
    {
        // Cast a ray from the bottom of the collider
        Vector2 rayOrigin = new Vector2(Collider.bounds.center.x, Collider.bounds.min.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, groundCheckDistance, GroundLayer);

        // Visualize the ray (optional, for debugging)
        // Debug.DrawRay(rayOrigin, Vector2.down * groundCheckDistance, hit.collider != null ? Color.green : Color.red);
        // Debug.Log(hit.collider != null);

        return hit.collider != null;
    }


}

// T: If the state is tied to the input, 
