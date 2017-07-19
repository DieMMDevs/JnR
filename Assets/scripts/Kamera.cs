using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour {
    public Vector3 offset;
    public Transform player;
    //public PlayerMovement playermovement;
    //public Camera camera;
	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
        //playermovement = GetComponent<PlayerMovement>();
        //camera = GetComponent<Camera>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position + offset;
	}
}
