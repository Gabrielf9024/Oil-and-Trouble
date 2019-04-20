using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    [SerializeField]
    private float speed, jumpHeight;
    private float xInput;

    private Rigidbody2D rb;

    [SerializeField]
    private int maxJumps, jumpsLeft;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpsLeft = maxJumps;
        }
    }

    void FixedUpdate()
    {
        // Left and Right movement
        xInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }

    void Update()
    {
        // Jumping
        if (Input.GetKeyDown("space") && jumpsLeft > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            --jumpsLeft;
        }
    }
}
