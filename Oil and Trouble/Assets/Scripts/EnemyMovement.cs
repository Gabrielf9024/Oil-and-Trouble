using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float damage;
    [SerializeField] int speed;
    public float timer;
    public float shootInterval = 4f;

    [SerializeField] Transform bullet;
    [SerializeField] int bulletSpeed;
    public bool canShoot;
    private float dirFacing = 1f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RobotMovement.coords.x < rb.position.x)
            dirFacing = -1f;
        else
            dirFacing = 1f;

        rb.velocity = new Vector2(dirFacing * speed, rb.velocity.y);

        if (canShoot)   //timer will never increment if canShoot is false, meaning the code below will never trigger.
            timer += Time.deltaTime;
        if (timer >= shootInterval)
        {
            if (dirFacing == 1f)
            {
                Transform bulletRef = Instantiate(bullet, transform.position + new Vector3(1, 0, 0), transform.rotation);
                bulletRef.GetComponent<Bullet>().SetBulletSpeed(bulletSpeed);
            }
            else
            {
                Transform bulletRef = Instantiate(bullet, transform.position + new Vector3(-1, 0, 0), Quaternion.Euler(0f, 0f, 180f));
                bulletRef.GetComponent<Bullet>().ChangeDirection();
                bulletRef.GetComponent<Bullet>().SetBulletSpeed(bulletSpeed * -1);
            }
            timer = 0f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
         collision.gameObject.GetComponent<Health>().DamageSelf(damage);
    }
}
