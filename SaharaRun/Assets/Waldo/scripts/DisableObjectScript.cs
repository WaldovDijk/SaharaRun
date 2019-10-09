using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableObjectScript : MonoBehaviour {

    private GameObject camera;
    [SerializeField]
    private float offset;

    private void Start()
    {
        camera = GameObject.Find("Main Camera");
    }
    private void Update()
    {
        if (transform.position.x < camera.transform.position.x - offset)
        {
            gameObject.SetActive(false);
        }
    }
}
