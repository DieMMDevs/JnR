using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public GameObject playerObject;
    public float damagevalue = 1;
    public string tags = "Player";

    public HealthController healthcontroller;

    // Use this for initialization
    void Start()
    {
        playerObject = GameObject.Find("Player");
        healthcontroller = playerObject.GetComponent<HealthController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tags)
        {
            other.gameObject.SendMessage("ApplyDamage", damagevalue, SendMessageOptions.DontRequireReceiver);
            healthcontroller.DamageTaken(damagevalue);
        }
    }
}