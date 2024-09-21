// using Managers;
// using UnityEngine;
// using UnityEngine.InputSystem;

// namespace Managers
// {
//     public class InputManagers : MonoBehaviour
//     {
//         public static InputManagers instance { get; private set; }
//         public InputAction InputAction { get; private set; }
//         public string testing { get { return "testing"; } private set { } }

//         void Awake()
//         {
//             Debug.Log("Im input manager");
//             if (instance != null && instance != this)
//             {
//                 Destroy(this);
//             }
//             else
//             {
//                 instance = this;

//             }

//         }


//     }

// }

// NOTE:
// 1. InputManager is a singleton

// public class testing {
//     InputManager input = new InputManager();
// void Start()
// {

//     if (InputManager.instance != null)
//     {
//         Debug.Log("input manager from awake");
//     }

//     Debug.Log(InputManager.instance.testing);
// }
// }