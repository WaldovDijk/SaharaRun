using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Range(1, 10)]
    public float m_jumpVelocity;

    private Rigidbody rb;

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

    public GameManager gameManager;

    public Movement m_Movement;

    //Attribute

    public float m_speed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -20.0F, 0);
    }
    void Start()
    {
        
    }

    void Update()
    {
        MoveRight();
        SwipeDetection();

    }

    void Jump()
    {
        rb.velocity = Vector3.up * m_jumpVelocity;        
    }
    void Fall()
    {
        rb.velocity = Vector3.down * m_jumpVelocity;
    }

    void SwipeDetection()
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

                        if(distance.y < 0)
                        {
                            Debug.Log("Down Swipe");
                            Fall();
                        }
                    }

                    if(Mathf.Abs(distance.y) < Mathf.Abs(distance.x))
                    {
                        if(distance.x > 0)
                        {
                            Debug.Log("Right Swipe");
                        }

                        if(distance.x < 0)
                        {
                            Debug.Log("Left Swipe");
                        }
                    }
                }

                startTimer = 0;
                endTimer = 0;

                startPos = Vector3.zero;
                endPos = Vector3.zero;
                swipeTime = 0;
                swipeDistance = 0;
            }
        }
    }

    void MoveRight()
    {
        transform.Translate(Vector2.right * m_speed * Time.deltaTime);
    }
}
