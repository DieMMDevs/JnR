using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = 1;
    float velocity;
    public float speed = 5;
    bool lookRight = true;
    bool jump = false;
    bool doublejump = true;
    public float jumpFactor = 20;

    private int count;
    public Text countText;

    public Vector3 moveDirection = Vector3.zero;
    public CharacterController characterController;
    public PlayerAnimations playerAnimations;

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<PlayerAnimations>();
        count = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        Input();
        Moving();
        SetAnimation();
    }

    public void Input()
    {
        velocity = UnityEngine.Input.GetAxis("Horizontal") * speed;

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
            jump = true;
        else
            jump = false;
    }

    public void Moving()
    {
        if (characterController.isGrounded) doublejump = true;
        if (characterController.isGrounded || doublejump)
        {
            if (jump && characterController.isGrounded)
            {
                moveDirection.y = jumpFactor * Time.deltaTime;
            }
            if(jump && doublejump && !characterController.isGrounded)
            {
                moveDirection.y = jumpFactor * Time.deltaTime;
                doublejump = false;
            }
        }
        if(!characterController.isGrounded) moveDirection.y -= gravity * Time.deltaTime;
        moveDirection.x = velocity * Time.deltaTime;
        if (velocity > 0)
            lookRight = true;
        else if (velocity < 0)
            lookRight = false;

        characterController.Move(moveDirection);
    }

    public void SetAnimation()
    {
        
        if (velocity > 0)
        {
            playerAnimations.currAnimation = PlayerAnimations.AniType.runRight;
            if (!characterController.isGrounded)
                playerAnimations.currAnimation = PlayerAnimations.AniType.jumpRight;
        }
        if (velocity < 0)
        {
            playerAnimations.currAnimation = PlayerAnimations.AniType.runLeft;
            if (!characterController.isGrounded)
                playerAnimations.currAnimation = PlayerAnimations.AniType.jumpLeft;
        }
        if (velocity == 0)
        {
            if (lookRight)
            {
                playerAnimations.currAnimation = PlayerAnimations.AniType.idleRight;
                if (!characterController.isGrounded) playerAnimations.currAnimation = PlayerAnimations.AniType.jumpRight;
            }
            else
            {
                playerAnimations.currAnimation = PlayerAnimations.AniType.idleLeft;
                if (!characterController.isGrounded) playerAnimations.currAnimation = PlayerAnimations.AniType.jumpLeft;
            } 
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Punkte: " + count.ToString();
    }
}
