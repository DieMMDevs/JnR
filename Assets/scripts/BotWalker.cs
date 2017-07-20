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
        Vector3 targetPosition = waypointPositions[currentwayPoint];    //Setze nächsten Wegpunkt
        targetPositionDelta = targetPosition - transform.position;      //"Legt" die Richtung fest 

        if (targetPositionDelta.sqrMagnitude <= 1)      //Wenn der Bot nahe am Wegpunkt ist
        {
            //nächster Wegpunkt bzw. von vorne 
            currentwayPoint++;
            if (currentwayPoint >= waypointPositions.Count) currentwayPoint = 0;
        }
        else
        {
            //Blickrichtung
            if (targetPositionDelta.x > 0) lookRight = true;
            else lookRight = false;

        }
        
    }
    void Moving()
    {
        moveDirection = targetPositionDelta.normalized * speed;             //Gleichbleibende Geschwindigkeit
        transform.Translate(moveDirection * Time.deltaTime, Space.World);   //neue Pos setzen
    }
    void SetAnimation()
    {
        //Animation setzen
        if(lookRight) playerAnimations.currAnimation = PlayerAnimations.AniType.runRight;
        else playerAnimations.currAnimation = PlayerAnimations.AniType.runLeft;
    }

}
