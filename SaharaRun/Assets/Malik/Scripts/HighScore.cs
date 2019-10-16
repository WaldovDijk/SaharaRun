using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text m_scoreText;
    private float m_score;
    [SerializeField] private float m_speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_scoreText.text =  "Score: " +  m_score.ToString("F0");
        AddScoresPerSec();
    }

    void AddScoresPerSec()
    {
        m_score += m_speed * Time.deltaTime;
    }
}
