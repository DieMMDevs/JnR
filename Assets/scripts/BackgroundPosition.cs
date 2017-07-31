using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPosition : MonoBehaviour
{
    GameObject playerObject;
    GameObject background;
    GameObject background2;
    string tagPlayer = "Player";
    string tagBG = "Background";
    string tagBG2 = "Background2";
    public float x, y, z, z2;
    public float shift = 1.22f, shift2 = 2f;

    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.Find(tagPlayer);
        background = GameObject.Find(tagBG);
        background2 = GameObject.Find(tagBG2);
        z = 2; z2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition();
        SetBackgroundPosition();
    }
    void PlayerPosition()
    {
        x = playerObject.transform.position.x;
        y = playerObject.transform.position.y;
    }
    void SetBackgroundPosition()
    {
        background.transform.position = new Vector3(x / shift, y / shift + 4, z);
        background2.transform.position = new Vector3(x / shift2, y / shift2 + 8, z2);
    }
}
