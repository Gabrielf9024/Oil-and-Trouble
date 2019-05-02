// This script handles the robot movement and shooting
// Anything that involves control

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RobotMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float speed, jumpHeight, doubleJumpMinimizer;
    private float xInput;
    private float dirFacing = 1f;

    public AudioSource audioSource;
    public AudioClip[] roboSounds;

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

    Scene scene;

    GameObject wintext;
    //private Animator anim; 

    private void Awake()   
    {
        rb = GetComponent<Rigidbody2D>();
        scene = SceneManager.GetActiveScene();
        wintext = GameObject.Find("WinText");
        wintext.SetActive(false);
        //anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (jumpsLeft < 2)
            {
                audioSource.clip = roboSounds[1];
                audioSource.pitch = 1.0f;
                audioSource.Play();
            }
            jumpsLeft = maxJumps;
        }

    }

    private void OnTriggerEnter2D( Collider2D trigger )
    { 
        if( trigger.gameObject.tag == "Death" )
        {
            SceneManager.LoadScene(scene.name);
        }
        if (trigger.gameObject.tag == "Win")
        {
            Time.timeScale = 0;
            wintext.SetActive(true);
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

        /*if (dirFacing == -1f)
        { anim.Play("robot_walk_left_anim.anim"); }*/
    }

    void Update()
    {
 /*       // Facing the right direction
        if (xInput > 0)
            right = true;
        else if (xInput == 0)
        { do nothing! }
        else
            right = false;
*/
        // Jumping
        if (Input.GetKeyDown(jumpButton) && jumpsLeft > 0)
        {
            if (jumpsLeft == maxJumps)
            {
                audioSource.clip = roboSounds[0];
                audioSource.pitch = 0.8f;
                audioSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            }
            else
            {
                audioSource.clip = roboSounds[0];
                audioSource.pitch = 1.0f;
                audioSource.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight * doubleJumpMinimizer);
            }

            --jumpsLeft;
        }

        // Shooting
        if (Input.GetKeyDown(shootKey) && GetComponent<RobotStatus>().getAmmo() > 0 )
        {
            if (dirFacing == 1f)
            {
                Transform bulletRef = Instantiate(bullet, transform.position + new Vector3(2, 0, -1), transform.rotation);
            }
            else
            {
                Transform bulletRef = Instantiate(bullet, transform.position + new Vector3(-2, 0, -1), Quaternion.Euler(0f, 0f, 180f));
                bulletRef.GetComponent<Bullet>().ChangeDirection();
            }
            GetComponent<RobotStatus>().addAmmo(-1);
        }

        coords = rb.position;
    }

}
