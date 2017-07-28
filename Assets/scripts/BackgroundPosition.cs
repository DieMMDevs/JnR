using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPosition : MonoBehaviour
{
    GameObject playerObject;
    string tags = "Player";
    public float playerPosition, y, z;
    public float playerPositionScroll = 0, yScroll = 0, zScroll = 0;

    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.Find(tags);
        playerPosition = playerObject.transform.position.x;
        y = 6.125f;
        z = 2.05f;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosition();
        SetBackgroundPosition();
    }
    void PlayerPosition()
    {
        playerPosition = playerObject.transform.position.x;
    }
    void SetBackgroundPosition()
    {
        this.transform.position = new Vector3(playerPosition + playerPositionScroll, y + yScroll, z + zScroll);
    }
}
