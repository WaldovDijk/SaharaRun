using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGeneration : MonoBehaviour {
    [SerializeField]
    private List<GameObject> m_Prefabs;
    [SerializeField]
    private GameObject m_Background;
    [SerializeField]
    private Transform m_SpawnPosition;
    [SerializeField]
    private float m_Distancebetween;
    [SerializeField]
    private float m_BackGroundWidth;

    // Use this for initialization
    void Start () {
        if (m_Background)
        {
            m_BackGroundWidth = m_Background.GetComponent<SpriteRenderer>().size.x;
        }
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.x < m_SpawnPosition.position.x)
        {
            Debug.Log("Spawn");
            transform.position = new Vector3(transform.position.x + m_BackGroundWidth + m_Distancebetween, transform.position.y, transform.position.z);

            Instantiate(m_Prefabs[Random.Range(1, m_Prefabs.Count)], transform.position, transform.rotation);
        }
	}
}
