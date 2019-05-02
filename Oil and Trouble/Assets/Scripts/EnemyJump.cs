using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    public float xThrust;
    public float yThrust;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(xThrust, yThrust), ForceMode2D.Impulse);
        }
    }
}
