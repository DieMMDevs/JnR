using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour {

    public Vector3 offset;
    public Transform player;

	void Start () {
        offset = transform.position - player.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
	}
}
