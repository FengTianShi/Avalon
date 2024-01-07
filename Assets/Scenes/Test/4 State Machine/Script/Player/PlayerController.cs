using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;

    Rigidbody2D rb;

    CapsuleCollider2D cc;

    [SerializeField]
    LayerMask groundLayer;

    public bool IsGrounded;

    public bool IsCeiling;

    public Vector2 Slope;

    [SerializeField]
    int groundCheckRayNum;

    [SerializeField]
    float groundCheckDistance;

    [SerializeField]
    int ceilingCheckRayNum;

    [SerializeField]
    float ceilingCheckDistance;

    [SerializeField]
    float slopeCheckDistance;

    public float XSpeed => rb.velocity.x;

    public float YSpeed => rb.velocity.y;

    void Awake()
    {
        // Application.targetFrameRate = 30;

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
        CheckCeiling();
        CheckSlope();
    }

    private void CheckGround()
    {
        Bounds bounds = cc.bounds;
        Vector2 startOrigin = new(bounds.min.x, bounds.center.y);
        float interval = bounds.size.x / (groundCheckRayNum - 1);
        float checkDistance = bounds.size.y / 2 + groundCheckDistance;

        for (int i = 0; i < groundCheckRayNum; i++)
        {
            Vector2 origin = startOrigin + interval * i * Vector2.right;
            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                Vector2.down,
                checkDistance,
                groundLayer);

            Debug.DrawRay(origin, Vector2.down * checkDistance, Color.blue);

            if (hit)
            {
                IsGrounded = true;
                return;
            }
        }

        IsGrounded = false;
    }

    private void CheckCeiling()
    {
        Bounds bounds = cc.bounds;
        Vector2 startOrigin = new(bounds.min.x, bounds.center.y);
        float interval = bounds.size.x / (ceilingCheckRayNum - 1);
        float checkDistance = bounds.size.y / 2 + ceilingCheckDistance;

        for (int i = 0; i < ceilingCheckRayNum; i++)
        {
            Vector2 origin = startOrigin + interval * i * Vector2.right;
            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                Vector2.up,
                checkDistance,
                groundLayer);

            Debug.DrawRay(origin, Vector2.up * checkDistance, Color.green);

            if (hit)
            {
                IsCeiling = true;
                return;
            }
        }

        IsCeiling = false;
    }

    private void CheckSlope()
    {
        Bounds bounds = cc.bounds;

        Vector2 origin = new(
            bounds.center.x + (transform.localScale.x > 0 ? 0.1f : -0.1f),
            bounds.center.y);

        float checkDistance = bounds.size.y / 2 + slopeCheckDistance;

        RaycastHit2D hit = Physics2D.Raycast(
            origin,
            Vector2.down,
            checkDistance,
            groundLayer);

        Debug.DrawRay(
            origin,
            Vector2.down * checkDistance,
            Color.red);

        if (hit && hit.normal != Vector2.up)
        {
            Slope = -Vector2.Perpendicular(hit.normal).normalized;
        }
        else
        {
            Slope = Vector2.zero;
        }
    }

    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector2(rb.velocity.x, velocityY);
    }

    public void SetVelocity(Vector2 velocity)
    {
        rb.velocity = velocity;
    }

    public void SetFacing()
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.Horizontal, 1, 1);
        }
    }

    public void Move(float speed)
    {
        if (Slope != Vector2.zero)
        {
            SetVelocity(speed * transform.localScale.x * Slope);
        }
        else
        {
            if (YSpeed > 0)
            {
                SetVelocityY(0);
            }

            SetVelocityX(speed * transform.localScale.x);
        }
    }
}
