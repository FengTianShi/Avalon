using UnityEngine;

public class CharacterController : MonoBehaviour
{
    protected Rigidbody2D RB;

    protected CapsuleCollider2D CC;

    public int HP;

    public int SP;

    public int MP;

    [SerializeField]
    protected LayerMask GroundLayer;

    [SerializeField]
    protected int GroundCheckRayNumber;

    [SerializeField]
    protected float GroundCheckDistance;

    [SerializeField]
    protected int CeilingCheckRayNumber;

    [SerializeField]
    protected float CeilingCheckDistance;

    [SerializeField]
    protected float SlopeCheckDistance;

    public bool IsGrounded;

    public bool IsCeiling;

    public Vector2 Slope;

    public float XSpeed => RB.velocity.x;

    public float YSpeed => RB.velocity.y;

    public bool IsFacingRight => transform.localScale.x > 0;

    protected virtual void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        CC = GetComponent<CapsuleCollider2D>();
    }

    protected virtual void Update()
    {
        CheckGround();
        CheckCeiling();
        CheckSlope();
    }

    protected virtual void CheckGround()
    {
        Bounds bounds = CC.bounds;
        Vector2 startOrigin = new(bounds.min.x, bounds.center.y);
        float interval = bounds.size.x / (GroundCheckRayNumber - 1);
        float checkDistance = bounds.size.y / 2 + GroundCheckDistance;

        for (int i = 0; i < GroundCheckRayNumber; i++)
        {
            Vector2 origin = startOrigin + interval * i * Vector2.right;
            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                Vector2.down,
                checkDistance,
                GroundLayer);

            Debug.DrawRay(origin, Vector2.down * checkDistance, Color.blue);

            if (hit)
            {
                IsGrounded = true;
                return;
            }
        }

        IsGrounded = false;
    }

    protected virtual void CheckCeiling()
    {
        Bounds bounds = CC.bounds;
        Vector2 startOrigin = new(bounds.min.x, bounds.center.y);
        float interval = bounds.size.x / (CeilingCheckRayNumber - 1);
        float checkDistance = bounds.size.y / 2 + CeilingCheckDistance;

        for (int i = 0; i < CeilingCheckRayNumber; i++)
        {
            Vector2 origin = startOrigin + interval * i * Vector2.right;
            RaycastHit2D hit = Physics2D.Raycast(
                origin,
                Vector2.up,
                checkDistance,
                GroundLayer);

            Debug.DrawRay(origin, Vector2.up * checkDistance, Color.green);

            if (hit)
            {
                IsCeiling = true;
                return;
            }
        }

        IsCeiling = false;
    }

    protected virtual void CheckSlope()
    {
        Bounds bounds = CC.bounds;

        Vector2 origin = new(
            bounds.center.x + (transform.localScale.x > 0 ? 0.1f : -0.1f),
            bounds.center.y);

        float checkDistance = bounds.size.y / 2 + SlopeCheckDistance;

        RaycastHit2D hit = Physics2D.Raycast(
            origin,
            Vector2.down,
            checkDistance,
            GroundLayer);

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

    public virtual void SetVelocity(Vector2 velocity)
    {
        RB.velocity = velocity;
    }

    public virtual void SetVelocityX(float velocityX)
    {
        RB.velocity = new Vector2(velocityX, RB.velocity.y);
    }

    public virtual void SetVelocityY(float velocityY)
    {
        RB.velocity = new Vector2(RB.velocity.x, velocityY);
    }

    public virtual void SetFacing(bool isRight)
    {
        transform.localScale = new Vector3(
            isRight ? 1 : -1,
            transform.localScale.y,
            transform.localScale.z);
    }

    public virtual void SetFacing(Transform target)
    {
        SetFacing(target.position.x > transform.position.x);
    }

    public virtual void Move(float speed)
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

    public virtual void Stop()
    {
        SetVelocityX(0);
        SetVelocityY(0);
    }
}
