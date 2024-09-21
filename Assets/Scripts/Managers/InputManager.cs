// using Managers;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.TextCore.Text;

// namespace Managers
// {
//     public class InputManager : MonoBehaviour
//     {
//         public PlayerInput InputAction;
//         private InputAction Move;

//         void Awake()
//         {
//             InputAction = GetComponent<PlayerInput>();
//             Move = InputAction.actions["Move"];
//             SetupInputCallbacks();

//         }


//         public void OnMove(InputAction.CallbackContext context)
//         {
//             Debug.Log("Move from OnMove");
//         }


//         // Attaching 
//         void SetupInputCallbacks()
//         {
//             // Assuming "Move" is the action name in your Input Action asset
//             Move.performed += OnMove;
//             Move.canceled += OnMove;

//         }

//         void OnDisable()
//         {
//             // Important: Unsubscribe from the event when the script is disabled
//             Move.performed -= OnMove;
//             Move.canceled -= OnMove;
//         }
//     }

// }

// // NOTE:
// // 1. InputManager is a singleton

// // public class testing {
// //     InputManager input = new InputManager();
// // }