using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput input;

    Rigidbody2D rb;

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        input.EnableGameplayInputs();
    }

    public void Move(float speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.Horizontal, 1, 1);
        }

        SetVelocityX(speed * input.Horizontal);
        SetVelocityY(0);
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
