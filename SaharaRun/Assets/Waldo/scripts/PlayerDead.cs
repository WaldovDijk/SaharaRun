using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{

    private Character m_Character;
    private Movement m_Movement;

    // Start is called before the first frame update
    void Start()
    {
        m_Character = GetComponent<Character>();
        m_Movement = GetComponent<Movement>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Obstacle")
        {
            Debug.Log("Dead");
            m_Character.enabled = false;
            m_Movement.enabled = false;
        }
    }
}
