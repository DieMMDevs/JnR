using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    public string tags = "Enemy";
    public float damagevalue = 10;
    GameObject enemyObject;
    HealthEnemy healthEnemy;
    // Use this for initialization
    void Start()
    {
        enemyObject = GameObject.Find(tags);
        healthEnemy = enemyObject.GetComponent<HealthEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tags)
        {
            other.gameObject.SendMessage("ApplyDamage", damagevalue, SendMessageOptions.DontRequireReceiver);
            healthEnemy.DamageTaken(damagevalue);
        }
    }
}
