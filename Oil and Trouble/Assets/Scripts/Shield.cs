using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D( Collision2D collision )
    {
        if( collision.gameObject.CompareTag("Bullet") )
        {
            //Debug.Log("hit shield");
            Destroy(collision.gameObject);
        }
    }
}
