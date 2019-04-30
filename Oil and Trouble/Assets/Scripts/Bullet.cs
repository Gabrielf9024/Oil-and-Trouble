﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed, damage;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Used for facing left
        if (!GameObject.FindWithTag("Player").GetComponent<RobotMovement>().right)
            speed *= -1;

        rb.velocity = new Vector2(speed, 0);
    }
    void Start()
    {
    }

    void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Health>().DamageSelf(damage);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }
}
