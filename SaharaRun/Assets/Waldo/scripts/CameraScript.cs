using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    [SerializeField]
    private GameObject m_Player;
	void Start () {
		
	}
	
	void Update ()
    {
        transform.position = new Vector3(m_Player.transform.position.x + 4, transform.position.y, transform.position.z);
	}
}
