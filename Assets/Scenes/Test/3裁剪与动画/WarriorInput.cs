using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;

public class WarriorInput : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private CapsuleCollider2D bodyCollider;

    [SerializeField]
    private CapsuleCollider2D footCollider;

    [SerializeField]
    private float xInput;

    [SerializeField]
    private int facing;

    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float glideSpeed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private bool isOnGround;

    [SerializeField]
    private bool isMovingOnGround;

    [SerializeField]
    private float slopeCheckDistance;

    [SerializeField]
    private bool isOnSlope;

    [SerializeField]
    Vector2 slopeDirLeft;

    [SerializeField]
    Vector2 slopeDirRight;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        UpdateFacing();

        CheckGround();

        CheckSlope();

        if (isOnGround)
        {
            Move();
            Jump();
        }
        else
        {
            Glide();
        }

        UpdateAnimator();
    }

    private void UpdateFacing()
    {
        if (xInput != 0)
        {
            facing = (int)xInput;
            transform.localScale = new Vector3(facing, 1, 1);
        }
    }

    private void CheckGround()
    {
        isOnGround = Physics2D.OverlapCapsule(
            footCollider.bounds.center,
            footCollider.bounds.size,
            CapsuleDirection2D.Vertical,
            0,
            groundLayer
        );
    }

    private void CheckSlope()
    {
        Bounds bounds = footCollider.bounds;
        Vector2 bottomPosition = new Vector2(bounds.center.x, bounds.min.y);

        RaycastHit2D leftHit = Physics2D.Raycast(bottomPosition, Vector2.left, slopeCheckDistance, groundLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(bottomPosition, Vector2.right, slopeCheckDistance, groundLayer);

        if (leftHit.collider == null && rightHit.collider == null)
            isOnSlope = false;
        else
            isOnSlope = true;

        if (leftHit.collider != null)
            slopeDirLeft = Vector2.Perpendicular(leftHit.normal).normalized;
        else
            slopeDirLeft = Vector2.zero;

        if (rightHit.collider != null)
            slopeDirRight = Vector2.Perpendicular(rightHit.normal).normalized;
        else
            slopeDirRight = Vector2.zero;
    }

    private void Move()
    {
        if (xInput != 0)
        {
            isMovingOnGround = true;

            if (isOnSlope)
                MoveOnSlope();
            else
                rb.velocity = new Vector2(xInput * runSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            isMovingOnGround = false;
        }
    }

    private void MoveOnSlope()
    {
        Vector2 slopeDirection;
        if (slopeDirLeft != Vector2.zero && slopeDirRight != Vector2.zero)
            slopeDirection = facing == 1 ? slopeDirRight : slopeDirLeft;
        else if (slopeDirLeft != Vector2.zero)
            slopeDirection = slopeDirLeft;
        else
            slopeDirection = slopeDirRight;

        rb.velocity = runSpeed * (new Vector2(xInput, 0) + (-xInput * slopeDirection) + new Vector2(0, -1)).normalized;
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }
    }

    private void Glide()
    {
        rb.velocity = new Vector2(xInput * glideSpeed, rb.velocity.y);
        isMovingOnGround = false;
    }

    private void UpdateAnimator()
    {
        animator.SetBool("isOnGround", isOnGround);
        animator.SetBool("isMovingOnGround", isMovingOnGround);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
}
