using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float multiplier;
    [SerializeField]
    private int speedX;
    [SerializeField]
    private int speedY;
    bool moving;
    [SerializeField]
    private Vector3 PlayerPosition;
    [SerializeField]
    private float maxSpeedPxSec;
    [SerializeField]
    private float boostSpeed;
    [SerializeField]
    private float boostSpeedManual;
    private Rigidbody rb;
    [SerializeField]
    private LayerMask layerMaskForGrounded;
    //Length of the raycast to check if the player is grounded or not
    private float isGroundedRayLength = 0.2f;
    Animator animator;
    [SerializeField]
    private Vector3 velocity;
    private bool isdead;
    public bool isDead
    {
        get { return isdead; }
        set { isdead = value; }
    }




    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        PlayerPosition = transform.position;
        moving = true;
    }
    private void Update()
    {
        multiplier += 0.2f * Time.deltaTime;
    }
    void FixedUpdate()
    {
        if (!isdead)
        {
            MovementPlayer();
        }
        if (isdead)
        {
            animator.SetBool("IsDead", true);
        }
    }
    void MovementPlayer()
    {
        if (gameObject.tag == "Player")
        {
            //Moving the player
            Vector3 move = rb.velocity;
            float hor = Input.GetAxis("Horizontal");

            move.x = velocity.x + multiplier;
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                move.y = velocity.y;
                animator.Play("Jump");
            }

            rb.velocity = move;
        }
    }
    public bool isGrounded
    {
        get
        {
            Vector3 position = transform.position;
          
            float length = isGroundedRayLength + 0.1f;
            Debug.DrawRay(position, Vector3.down * length);
            bool grounded = Physics2D.Raycast(position, Vector3.down, length, layerMaskForGrounded.value);
            return grounded;
        }
    }
}
