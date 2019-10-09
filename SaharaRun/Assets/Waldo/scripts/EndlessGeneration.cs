using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGeneration : MonoBehaviour {
    [SerializeField]
    private List<GameObject> Backgrounds;
    [SerializeField]
    private GameObject Background;
    [SerializeField]
    private Transform SpawnPosition;
    [SerializeField]
    private float distancebetween;
    [SerializeField]
    private float BackGroundWidth;

    // Use this for initialization
    void Start () {
        if (Background)
        {
            BackGroundWidth = Background.GetComponent<SpriteRenderer>().size.x;
        }
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.x < SpawnPosition.position.x)
        {
            Debug.Log("Spawn");
            transform.position = new Vector3(transform.position.x + BackGroundWidth + distancebetween, transform.position.y, transform.position.z);

            Instantiate(Backgrounds[Random.Range(1, Backgrounds.Count)], transform.position, transform.rotation);
            //SpawnBackground();
        }
	}
}
