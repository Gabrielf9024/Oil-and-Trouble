// This script handles the robot movement and shooting
// Anything that involves control

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed, jumpHeight, doubleJumpMinimizer;
    private float xInput;
    private float dirFacing = 1f;

    private Rigidbody2D rb;

    [SerializeField]
    private int maxJumps, jumpsLeft;

    [Header("Controls")]
    [SerializeField] string movementAxis = "Horizontal";
    [SerializeField] string jumpButton = "space";

    [Header("Shooting")]
    [SerializeField] string shootKey = "j";
    [SerializeField] Transform bullet;

    public static Vector2 coords;

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
        xInput = Input.GetAxisRaw(movementAxis);
        if (xInput > 0)
            dirFacing = 1f;
        else if (xInput < 0)
            dirFacing = -1f;
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }

    void Update()
    {
        // Jumping
        if (Input.GetKeyDown(jumpButton) && jumpsLeft > 0)
        {
            if(jumpsLeft == maxJumps)
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            else
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight * doubleJumpMinimizer);

            --jumpsLeft;
        }

        // Shooting
        if (Input.GetKeyDown(shootKey) && GetComponent<RobotStatus>().getAmmo() > 0 )
        {
            if (dirFacing == 1f)
            {
                Transform bulletRef = Instantiate(bullet, transform.position + new Vector3(1, 0, 0), transform.rotation);
            }
            else
            {
                Transform bulletRef = Instantiate(bullet, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler(0f, 0f, 180f));
                bulletRef.GetComponent<Bullet>().ChangeDirection();
            }
            GetComponent<RobotStatus>().addAmmo(-1);
        }

        coords = rb.position;
    }

}
