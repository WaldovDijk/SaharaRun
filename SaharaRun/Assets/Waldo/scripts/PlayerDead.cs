using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{

    private Character m_Character;
    private Movement m_Movement;

    [SerializeField] private GameObject m_Player;

    // Start is called before the first frame update
    void Start()
    {
        m_Character = m_Player.GetComponent<Character>();
        m_Movement = m_Player.GetComponent<Movement>();
    }


    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag == "Obstacle")
        {
           
            m_Character.enabled = false;
            m_Movement.enabled = false;
        }
    }
}
