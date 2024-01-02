using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitcherInput : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    private CapsuleCollider2D capsuleCollider;

    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private float jumpForce = 5;

    [SerializeField]
    private float xInput;

    [SerializeField]
    private int facing = 1;

    [SerializeField]
    private bool isMoving;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        groundLayer = LayerMask.GetMask("Ground");
    }

    void Update()
    {
        // xInput = Input.GetAxisRaw("Horizontal");

        UpdateFacing();

        CheckIsGrounded();

        if (isGrounded)
        {
            Run();
            Jump();
        }

        UpdateAnimator();
    }

    private void Run()
    {
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        isMoving = rb.velocity.x != 0;
    }

    private void Jump()
    {
        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //     isGrounded = false;
        // }
    }

    private void UpdateFacing()
    {
        if (xInput != 0)
        {
            facing = (int)xInput;
            transform.localScale = new Vector3(facing, 1, 1);
        }
    }

    private void CheckIsGrounded()
    {
        isGrounded = Physics2D.OverlapCapsule(capsuleCollider.bounds.center, capsuleCollider.size, CapsuleDirection2D.Vertical, 0, groundLayer);
    }

    private void UpdateAnimator()
    {
        anim.SetBool("isMoving", isMoving);
    }
}
