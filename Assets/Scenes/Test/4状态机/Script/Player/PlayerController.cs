using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;

    Rigidbody2D rb;

    CapsuleCollider2D cc;

    [SerializeField]
    LayerMask groundLayer;

    public bool IsGrounded;

    public Vector2 Slope;

    [SerializeField]
    int groundCheckRayNum;

    [SerializeField]
    float groundCheckDistance;

    [SerializeField]
    int slopeCheckDistance;

    public float XSpeed => rb.velocity.x;

    public float YSpeed => rb.velocity.y;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    void Start()
    {
        input.EnableGameplayInputs();
    }

    void Update()
    {
        CheckGround();
        CheckSlope();
    }

    private void CheckGround()
    {
        Bounds bounds = cc.bounds;
        Vector2 startOrigin = new(bounds.min.x, bounds.center.y);
        float rayInterval = bounds.size.x / (groundCheckRayNum - 1);
        float checkDistance = bounds.size.y / 2 + groundCheckDistance;

        for (int i = 0; i < groundCheckRayNum; i++)
        {
            Vector2 rayOrigin = startOrigin + rayInterval * i * Vector2.right;
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, checkDistance, groundLayer);

            Debug.DrawRay(rayOrigin, Vector2.down * checkDistance, Color.red);

            if (hit)
            {
                IsGrounded = true;
                return;
            }
        }

        IsGrounded = false;
    }

    private void CheckSlope()
    {
        Bounds bounds = cc.bounds;

        Vector2 origin;
        if (transform.localScale.x > 0)
            origin = new Vector2(bounds.center.x + 0.1f, bounds.center.y);
        else
            origin = new Vector2(bounds.center.x - 0.1f, bounds.center.y);

        RaycastHit2D hit = Physics2D.Raycast(
            origin,
            Vector2.down,
            slopeCheckDistance,
            groundLayer);

        Debug.DrawRay(
            origin,
            Vector2.down * slopeCheckDistance,
            Color.blue);

        if (hit && hit.normal != Vector2.up)
            Slope = Vector2.Perpendicular(hit.normal).normalized;
        else
            Slope = Vector2.zero;
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }
}
