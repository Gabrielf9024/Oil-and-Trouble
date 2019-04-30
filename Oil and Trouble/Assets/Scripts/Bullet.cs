using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed, damage;
    Rigidbody2D rb;

    private float timer = 0f;
    private float timeToLive = 6f;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(speed, 0);


        // Used for facing left
        if (!GameObject.FindWithTag("Player").GetComponent<RobotMovement>().right)
            speed *= -1;

        rb.velocity = new Vector2(speed, 0);
    }
    void Start()
    {
        rb.velocity = new Vector2(speed, 0);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeToLive)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Health>().DamageSelf(damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Bullet"))
        {
            //nothing
        }
        else
            Destroy(gameObject);
    }

    public void ChangeDirection()
    {
        speed *= -1;
    }

    public void SetBulletSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
