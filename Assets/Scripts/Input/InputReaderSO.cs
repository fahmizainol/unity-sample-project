using System;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "InputReaderSO")]
public class InputReaderSO : ScriptableObject, GameInput.IPlayerActions
{
    private GameInput _gameInput;

    public string test;

    private void OnEnable()
    {
        if (_gameInput == null)
        {
            _gameInput = new GameInput();
            _gameInput.Player.SetCallbacks(this); // NOTE: Setting the InputReaderSO instance to receive notifications
            // _gameInput.UI.SetCallbacks(this);

            Debug.Log("On Enable INputReaderSO");

            // SetPlayer(); NOTE: Can't put it here need to call it from the MonoBehaviour class FFS
        }
        else
        {
            Debug.Log("not null gameinput");
        }
    }

    public void EnablePlayerInput()
    {
        _gameInput.Player.Enable();
    }


    // NOTE: We are not using context because we will have to parse them everytime
    // E.g: context.ReadValue<Vector2>() bla bla
    // So we will create our own public events
    // Events are a way to implement Observer pattern in C# which is basically broadcasting an event that happen
    // in the lifecycle of the game. E.g: Kill 100 enemies achievement system etc
    public event Action<Vector2> MoveEvent;
    // public event Action JumpEvent;
    // public event Action JumpEventCancelled;
    public void OnAttack(InputAction.CallbackContext context)
    {

    }



    public void OnJump(InputAction.CallbackContext context)
    {

    }


    public void OnMove(InputAction.CallbackContext context)
    {
        MoveEvent?.Invoke(context.ReadValue<Vector2>());

        Debug.Log($"Phase {context.phase} Value: {context.ReadValue<Vector2>()}");
        // Debug.Log("Onmove");
    }



    public void OnRun(InputAction.CallbackContext context)
    {

    }

    public void OnLook(InputAction.CallbackContext context)
    {
    }
}