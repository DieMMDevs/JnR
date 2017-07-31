using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchControlls : MonoBehaviour {
    GameObject gui, gui2;
    string left = "Left", right = "Right";
    
	// Use this for initialization
	void Start ()
    {
        gui = GameObject.Find(left);
    }
	
	// Update is called once per frame
	void Update () {
        int touchCount = Input.touchCount;
        Vector2 v2 = gui.transform.position;

        for(int i = 0; i < touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            Debug.Log(touch.position);
            Debug.Log(v2);

            if (touch.position == v2)
            {
                Debug.Log("läuft");
            }
        }
	}
}
