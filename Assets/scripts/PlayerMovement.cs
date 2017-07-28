using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    bool lookRight = true;
    bool jump = false;
    bool doublejump = true;
    bool attackR = false;
    bool attackL = false;

    float waitSecounds = 0.25f;
    float velocity;
    public float gravity = 1;
    public float speed = 5;
    public float jumpFactor = 20;
    private int count;

    string background = "Background";

    public Text countText;

    public GameObject otherGameObject;
    public GameObject backgroundObject;
    BackgroundPosition bgPosition;


    Vector3 moveDirection = Vector3.zero;
    HealthController healthController;
    CharacterController characterController;
    PlayerAnimations playerAnimations;
    GameObject attack;
    GameObject player;
    Vector3 attackposition = Vector3.zero;
    // Use this for initialization
    void Start()
    {
        healthController = GetComponent<HealthController>();
        characterController = GetComponent<CharacterController>();
        playerAnimations = GetComponent<PlayerAnimations>();
        count = 0;
        SetCountText();
        attack = GameObject.Find("Attack");
        attack.SetActive(true);
        player = GameObject.Find("Player");
        backgroundObject = GameObject.Find(background);
        bgPosition = backgroundObject.GetComponent<BackgroundPosition>();
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
        velocity = UnityEngine.Input.GetAxis("Horizontal") * speed; //Richtung und Geschwindigkeit 

        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))    //Sprungtaste gedrückt?     
            jump = true;
        else
            jump = false;
        if (UnityEngine.Input.GetKeyDown(KeyCode.K))    //attackRechts gedrückt?     
            attackR = true;
        if (UnityEngine.Input.GetKeyDown(KeyCode.J))    //attackLinks gedrückt?     
            attackL = true;
    }

    public void Moving()
    {
        if (characterController.isGrounded) doublejump = true;  //Setzt doubleJump zurück 
        if (characterController.isGrounded || doublejump)   //Vorraussetzungen zum Sprung erfüllt?
        {
            //"normaler" Sprung
            if (jump && characterController.isGrounded)
            {
                moveDirection.y = jumpFactor * Time.deltaTime;
            }
            //doubleJump Sprung
            if (jump && doublejump && !characterController.isGrounded)
            {
                moveDirection.y = jumpFactor * Time.deltaTime;
                doublejump = false;
            }
        }
        //Nur wenn der Player in der Luft ist soll gravity gelten
        if (!characterController.isGrounded) moveDirection.y -= gravity * Time.deltaTime;
        moveDirection.x = velocity * Time.deltaTime;    //Player bewegung
        //Blickrichtung
        if (velocity > 0)
            lookRight = true;
        else if (velocity < 0)
            lookRight = false;

        characterController.Move(moveDirection);
    }

    public void SetAnimation()
    {
        //Laufrichtungs-Animation setzten und im Inneren Jump-Animation abfrage
        if (velocity > 0)
        {
            playerAnimations.currAnimation = PlayerAnimations.AniType.runRight;
            if (!characterController.isGrounded)
                playerAnimations.currAnimation = PlayerAnimations.AniType.jumpRight;
            bgPosition.playerPositionScroll -= 0.02f;
        }
        if (velocity < 0)
        {
            playerAnimations.currAnimation = PlayerAnimations.AniType.runLeft;
            if (!characterController.isGrounded)
                playerAnimations.currAnimation = PlayerAnimations.AniType.jumpLeft;

            bgPosition.playerPositionScroll += 0.02f;
        }
        //Blickrichtungs-Animation setzten und im Inneren Jump-Animation abfrage
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
        //Attack animation
        if (attackR)
        {
            playerAnimations.currAnimation = PlayerAnimations.AniType.attackRight;
            attackposition = player.transform.position;
            attackposition.x += 0.5f;
            attack.transform.position = attackposition;
            playerAnimations.speed = 0;
            StartCoroutine(WaitSecounds());
        }
        if (attackL)
        {
            playerAnimations.currAnimation = PlayerAnimations.AniType.attackLeft;
            playerAnimations.speed = 0;
            attackposition = player.transform.position;
            attackposition.x -= 0.5f;
            attack.transform.position = attackposition;
            StartCoroutine(WaitSecounds());
        }
    }
    IEnumerator WaitSecounds()
    {
        yield return new WaitForSeconds(waitSecounds);
        attackR = false;
        attackL = false;
        attackposition.y = 20;
        attack.transform.position = attackposition;
        playerAnimations.speed = 10;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            otherGameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (healthController.currentHealth < healthController.maxHealth)
            {
                healthController.currentHealth++;
                healthController.ShowHealth();
            }
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
