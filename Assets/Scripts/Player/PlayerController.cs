using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Vector2 moveInput; // can be checked by referring to PlayerInputActions > Action Properties
    Rigidbody2D rb;
    Animator animator;

    public float walkSpeed = 5f;
    public float airWalkSpeed = 5f;
    public float runSpeed = 18f;
    public float jumpSpeed = 20f;


    public float CurrentMoveSpeed
    {
        // TODO: Make a runnning jump logic
        get
        {
            // if (!IsMoving || touchingDirections.IsOnWall) return 0; // idle speed
            // if (!touchingDirections.IsGrounded) return walkSpeed; // In the air
            // if (!touchingDirections.IsGrounded && IsRunning) return runSpeed; // In the air
            // if (IsRunning)
            //     return runSpeed;
            // else
            return walkSpeed;
        }
        set
        {

        }
    }

    private float attackDelay = 0.3f;



    private bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    [SerializeField] // NOTE: To make it appear on the Inspector UI
    private bool _isMoving = false;
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
        }
    }

    [SerializeField]
    private bool _isRunning = false;
    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
        }
    }

    [SerializeField]
    private bool _isJumping = false;

    public bool IsJumping
    {
        get
        {
            return _isJumping;
        }
        set
        {
            _isJumping = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();  // is referencing the property of RigidBody rb 
        animator = GetComponent<Animator>();
    }

    // NOTE: Flipping the scale instead of flipping the sprite in the Sprite Renderer because it will make it easier for the child
    // of the Player to flip also. If flipped in the Sprite Renderer, the child will not be flipped with the parent (Player)
    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    // NOTE: Update runs once per frame. FixedUpdate can run once, zero, or several times per frame,
    // In short, normally physics calculations are best done in FixedUpdate, such as rigidbody velocity, etc.
    // FixedUpdate should generally be used anytime you are adding forces directly to a rigidbody.4 Dec 2021



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);

        Debug.Log("am moving");
    }

    public void onRun(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.started)
        {
            IsRunning = true;
            Debug.Log("Running started");
        }
        else if (context.canceled)
        {
            IsRunning = false;
            Debug.Log("Running ends");
        }
    }

    public void onJump(InputAction.CallbackContext context)
    {
        Debug.Log("onJump");
        if (context.started)
        {
            IsJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, 10f);

        }
        else if (context.canceled && rb.velocity.y > 0f)
        {
            IsJumping = false;
            Debug.Log("space cancekled");
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }
    }

    public void EndAttackAnimation()
    {
        //animator.SetBool(AnimationStrings.attack, false);

    }



    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(attackDelay);
    }
}

// NOTES on the full picture of what is happening 
// This is a simplified mock-up, not actual Unity code
//public class GameObject
//{
//    private List<Component> components = new List<Component>();

//    public T GetComponent<T>() where T : Component
//    {
//        return components.OfType<T>().FirstOrDefault();
//    }

//    public void AddComponent(Component component)
//    {
//        components.Add(component);
//    }
//}

//public abstract class Component
//{
//    public GameObject gameObject { get; set; }
//}

//public class Rigidbody2D : Component
//{
//    public Vector2 velocity { get; set; }
//    public float mass { get; set; }
//    // Other Rigidbody2D properties and methods...
//}

//public class PlayerController : Component
//{
//    private Vector2 moveInput;
//    private Rigidbody2D rb;
//    public float walkSpeed = 5f;
//    public bool IsMoving { get; private set; }

//    void Start()
//    {
//        // This is how we get the reference to the Rigidbody2D
//        rb = gameObject.GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        // Use rb to manipulate the physics of the object
//        if (IsMoving)
//        {
//            rb.velocity = moveInput * walkSpeed;
//        }
//    }

//    void OnMove(InputAction.CallbackContext context)
//    {
//        moveInput = context.ReadValue<Vector2>();
//        IsMoving = moveInput != Vector2.zero;
//    }
//}

//// Usage
//GameObject player = new GameObject();
//player.AddComponent(new Rigidbody2D());
//player.AddComponent(new PlayerController());
