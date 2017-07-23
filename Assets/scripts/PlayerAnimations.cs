using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour {

    public List<Texture2D> idleAnimationRight;
    public List<Texture2D> idleAnimationLeft;
    public List<Texture2D> runAnimationRight;
    public List<Texture2D> runAnimationLeft;
    public List<Texture2D> jumpAnimationRight;
    public List<Texture2D> jumpAnimationLeft;

    public float speed = 10;

    public enum AniType
    {
        idleLeft,
        idleRight,
        runLeft,
        runRight,
        jumpLeft,
        jumpRight
    }

    public AniType currAnimation = AniType.idleRight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Auswahl der Animation
        switch (currAnimation) {
            case AniType.idleLeft:
                SetAnimation(idleAnimationLeft);
                break;
            case AniType.idleRight:
                SetAnimation(idleAnimationRight);
                break;
            case AniType.runLeft:
                SetAnimation(runAnimationLeft);
                break;
            case AniType.runRight:
                SetAnimation(runAnimationRight);
                break;
            case AniType.jumpLeft:
                SetAnimation(jumpAnimationLeft);
                break;
            case AniType.jumpRight:
                SetAnimation(jumpAnimationRight);
                break;
        }
	}

    void SetAnimation(List<Texture2D> listAnimations)
    {
        //Berechnung des Bildes
        Renderer rend = GetComponent<Renderer>();
        int index = (int)(Time.time * speed);
        index %= listAnimations.Count;
        rend.material.mainTexture = listAnimations[index];
    }
}
