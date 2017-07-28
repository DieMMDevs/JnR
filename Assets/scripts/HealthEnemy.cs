using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public float health = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageTaken(float damagevalue)
    {
        health -= damagevalue;
        if (health <= 0)
        {
            this.enabled = false;
        }
    }
}
