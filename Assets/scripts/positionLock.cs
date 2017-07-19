using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionLock : MonoBehaviour {
    public float axisOffset = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.z = 0 + axisOffset;
        transform.position = pos;
	}
}
