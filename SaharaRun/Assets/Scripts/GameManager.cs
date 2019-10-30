using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool GameStart = false;
    public GameObject m_Player;
    public GameObject m_Sprite;
    // Start is called before the first frame update
    void Start()
    {

        m_Player.GetComponent<Movement>().enabled = false;
        m_Player.GetComponent<Character>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount > 0)
        {
            GameStart = true;
        }

        if (GameStart == false)
        {
            m_Player.GetComponent<Movement>().enabled = false;
            m_Player.GetComponent<Character>().enabled = false;
        }
        else
        {
            m_Player.GetComponent<Movement>().enabled = true;
            m_Player.GetComponent<Character>().enabled = true;
            m_Sprite.gameObject.SetActive(false);
        }
    }

    public void GamePause()
    {
        m_Player.GetComponent<Movement>().enabled = false;
        m_Player.GetComponent<Character>().enabled = false;
    }

    public void GameUnpause()
    {
        m_Player.GetComponent<Movement>().enabled = true;
        m_Player.GetComponent<Character>().enabled = true;
    }
}
