using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemy : MonoBehaviour {
    public float damagevalue = 1;
    public string tag = "Player";

    public HealthController healthcontroller;
	// Use this for initialization
	void Start () {
        healthcontroller = new HealthController();
        healthcontroller.DamageTaken(damagevalue);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == tag)
        {
            healthcontroller.DamageTaken(damagevalue);
        }
    }
}
