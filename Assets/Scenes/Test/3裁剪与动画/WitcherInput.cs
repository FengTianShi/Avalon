using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitcherInput : MonoBehaviour
{
    private Rigidbody2D rb;

    private Animator anim;

    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private float jumpForce = 10;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        anim.SetBool("isMoving", rb.velocity.x != 0);
    }
}
