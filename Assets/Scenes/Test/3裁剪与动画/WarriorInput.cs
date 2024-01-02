using System;
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

    [SerializeField]
    private float dashDuration;

    [SerializeField]
    private float dashSpeed;

    [SerializeField]
    private float dashTime;

    [SerializeField]
    private bool isDashing;

    [SerializeField]
    Vector2 dashDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        // xInput = Input.GetAxisRaw("Horizontal");

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

        Dash();

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

    private Vector2 GetMoveDir()
    {
        Vector2 moveDir = new Vector2(xInput, 0);

        if (isOnSlope)
        {
            Vector2 slopeDir;
            if (slopeDirLeft != Vector2.zero && slopeDirRight != Vector2.zero)
                slopeDir = facing == 1 ? slopeDirRight : slopeDirLeft;
            else if (slopeDirLeft != Vector2.zero)
                slopeDir = slopeDirLeft;
            else
                slopeDir = slopeDirRight;

            moveDir = -xInput * slopeDir;

            // Slope speed adjustment
            if (xInput != 0)
                moveDir += new Vector2(0, -1);
        }

        return moveDir.normalized;
    }

    private void Move()
    {
        rb.velocity = runSpeed * GetMoveDir();
        isMovingOnGround = rb.velocity.x != 0;
    }

    private void Dash()
    {
        dashTime -= Time.deltaTime;

        // if (Input.GetKeyDown(KeyCode.LeftShift))
        // {
        //     dashTime = dashDuration;
        // }
        if (dashTime > 0)
        {
            if (dashDir == null || dashDir == Vector2.zero)
                dashDir = GetMoveDir();
            rb.velocity = dashSpeed * dashDir;
            isDashing = true;
        }
        else
        {
            dashDir = Vector2.zero;
            isDashing = false;
        }
    }

    private void Jump()
    {
        // if (Input.GetButton("Jump") && isOnGround && !isDashing)
        // {
        //     rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        //     isOnGround = false;
        // }
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
        animator.SetBool("isDashing", isDashing);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
}
