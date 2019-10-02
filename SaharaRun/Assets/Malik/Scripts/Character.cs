using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Range(1, 10)]
    public float m_jumpVelocity;

    private Rigidbody2D rb;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    //Swipe
    public float maxTime;
    public float minSwipeDist;

    private float startTimer;
    private float endTimer;

    private Vector3 startPos;
    private Vector3 endPos;

    private float swipeDistance;
    private float swipeTime;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        SwipeToJump();  
    }

    void Jump()
    {
        rb.velocity = Vector2.up * m_jumpVelocity;        

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    }

    void SwipeToJump()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startTimer = Time.time;
                startPos = touch.position;
            }
            else if(touch.phase == TouchPhase.Ended)
            {
                endTimer = Time.time;
                endPos = touch.position;
                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTimer - startTimer;

                if(swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    Vector2 distance = endPos - startPos;
                    if(Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
                    {
                        if(distance.y > 0)
                        {
                            Debug.Log("Up Swipe");
                            Jump();
                        }
                    }
                }
            }
        }
    }
}
