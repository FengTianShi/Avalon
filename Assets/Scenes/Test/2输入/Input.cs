using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField]
    private float moveSpeed = 10;

    [SerializeField]
    private float jumpForce = 10;

    void Start()
    {
        Debug.Log("Started");

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(Random.Range(0, 50), Random.Range(0, 50));
    }

    void Update()
    {
        // Debug.Log(Input.GetAxis("Horizontal"));

        // float xInput = Input.GetAxisRaw("Horizontal");

        // rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    Debug.Log("Jump hoding");
        //}

        //if (Input.GetButtonUp("Jump"))
        //{
        //    Debug.Log("Jump pressed");
        //}

        // if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
        // {
        //     // rb.AddForce(new Vector2(0, 500));
        //     rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        // }

    }
}
