using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Uses the collider to check the current state of the player (whether in the ground, in the air, touching the ceiling, etc)
public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFiler;
    public float groundDistance = 0.05f;
    public float wallDistance = 0.2f;
    public float ceilingDistance = 0.05f;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];


    CapsuleCollider2D touchingCol;
    Animator animator;

    [SerializeField]
    private bool _isGrounded;
    private bool _isOnWall;
    private bool _isOnCeiling;
    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    public bool IsGrounded 
    {   get { return _isGrounded; } 
        set
        { 
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        } 
    }

    public bool IsOnWall
    {
        get { return _isOnWall; }
        set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        }
    }

    public bool IsOnCeiling
    {
        get { return _isOnCeiling; }
        set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Checking to see if object is in the ground
        // 2nd arg is filter to check if we are colliding with the right colliders (ground, wall)
        // will return a groundHits array and an int > 0, it is touching the ground
        IsGrounded = touchingCol.Cast(Vector2.down, castFiler, groundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFiler, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFiler, ceilingHits, ceilingDistance) > 0;

    }
}
