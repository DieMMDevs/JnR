using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotWalker: MonoBehaviour {

    public float speed = 4;
    public List<Vector3> waypointPositions;
    int currentwayPoint = 0;
    bool lookRight = true;
    Vector3 targetPositionDelta;
    Vector3 moveDirection = Vector3.zero;
    public PlayerAnimations playerAnimations;

    // Use this for initialization
    void Start () {
        playerAnimations = GetComponent<PlayerAnimations>();
    }
	
	// Update is called once per frame
	void Update () {
        BotWalk();
        Moving();
        SetAnimation();
    }

    void BotWalk()
    {
        Vector3 targetPosition = waypointPositions[currentwayPoint];
        targetPositionDelta = targetPosition - transform.position;

        if (targetPositionDelta.sqrMagnitude <= 1)
        {
            currentwayPoint++;
            if (currentwayPoint >= waypointPositions.Count) currentwayPoint = 0;
        }
        else
        {
            if (targetPositionDelta.x > 0) lookRight = true;
            else lookRight = false;

        }
        
    }
    void Moving()
    {
        moveDirection = targetPositionDelta.normalized * speed;
        transform.Translate(moveDirection * Time.deltaTime, Space.World);
    }
    void SetAnimation()
    {
        if(lookRight) playerAnimations.currAnimation = PlayerAnimations.AniType.runRight;
        else playerAnimations.currAnimation = PlayerAnimations.AniType.runLeft;
    }

}
