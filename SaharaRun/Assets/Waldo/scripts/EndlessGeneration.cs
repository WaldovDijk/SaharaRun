using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGeneration : MonoBehaviour {

    [SerializeField] Transform m_Spawn;
    [SerializeField]
    private List<GameObject> m_Prefabs;
    [SerializeField]
    private Transform m_SpawnPosition;
    [SerializeField]
    private float m_Distancebetween;


    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {

		if(transform.position.x < m_SpawnPosition.position.x)
        {
            Debug.Log("Spawn");
            transform.position = new Vector3(transform.position.x + m_Distancebetween, m_Spawn.transform.position.y, m_Spawn.transform.position.z);

            Instantiate(m_Prefabs[Random.Range(0, m_Prefabs.Count)], transform.position, transform.rotation);
        }
	}
}
