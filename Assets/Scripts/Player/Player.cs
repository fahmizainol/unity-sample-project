using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;

    public Vector2 _inputVector;
    private bool _isFacingRight = true;
    private PlayerStateMachine _stateMachine;

    public float Speed = 10f;

    public Rigidbody2D RB;
    public Animator Anim;

    void Awake()
    {
        Debug.Log("player awake");
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();

        _inputReader.EnablePlayerInput();
    }

    void Start()
    {
        _inputReader.MoveEvent += HandleMove;
    }



    void Update()
    {
        // inputReader.MoveEvent += OnMove;
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
        _inputVector = inputVector;
        SetFacingDirection(_inputVector);
    }


}

// T: If the state is tied to the input, 
