using System;
using Managers;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    // [SerializeField] private InputReaderSO inputReader;

    public GameInput GameInput;

    Rigidbody2D RB;
    Animator Anim;


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

    void Awake()
    {
        Debug.Log("player awake");
        RB = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        GameInput = new GameInput();
        GameInput.Player.SetCallbacks((GameInput.IPlayerActions)this);

    }

    void Start()
    {

        Debug.Log(inputReader.test);
    }



    void Update()
    {
        // inputReader.MoveEvent += OnMove;

    }
    public void OnMove(Vector2 vec)
    {
        Debug.Log("am moving");
    }
}
