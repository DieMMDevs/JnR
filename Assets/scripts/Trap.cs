using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour {
    Vector3 hoehe;
    GameObject trap;
    public float gravity = 2;
	// Use this for initialization
	void Start () {
        trap = GameObject.Find("Trap");
        hoehe = trap.transform.position;
        hoehe.y = 4;
    }
	
	// Update is called once per frame
	void Update () {
        hoehe.y -= gravity * Time.deltaTime;
        trap.transform.position = hoehe;
        if (trap.transform.position.y <= 1.4)
        {
            hoehe.y = 4;
            trap.transform.position = hoehe;
        }
	}
}
