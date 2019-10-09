using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLOAD : MonoBehaviour
{
	void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
	}
}
