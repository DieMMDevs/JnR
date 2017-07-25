using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trap : MonoBehaviour {
    Vector3 hoehe;
    GameObject trap;
    public float gravity = 1;
    public float seconds = 1;
	// Use this for initialization
	void Start () {
        trap = GameObject.Find("Trap");
        hoehe = trap.transform.position;
        hoehe.y = 7;
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(warten());
        if (trap.transform.position.y <= 1.4)
        {
            hoehe.y = 7;
            trap.transform.position = hoehe;
        }
	}
    IEnumerator warten()
    {
        hoehe.y -= gravity;
        yield return new WaitForSeconds(seconds);
        trap.transform.position = hoehe;
        yield return new WaitForSeconds(seconds);
    }
}
