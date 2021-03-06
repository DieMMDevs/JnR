﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public float health = 10;
    public int life = 3;
    public float seconds = 1;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageTaken(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0)
            {
                if (life > 0)
                {
                    life--;
                    RestartLevel();
                }
                else
                {
                    //Game Over
                }
            }
            StartCoroutine(DamageEffect());
        }
    }

    void RestartLevel()
    {
        //Application.LoadLevel(Application.loadedLevel);

        SceneManager.LoadScene("main", LoadSceneMode.Single);

        //UnityEngine.SceneManagement.SceneManager.LoadScene();
    }

    IEnumerator DamageEffect()
    {
        Renderer rend = GetComponent<Renderer>();
        rend.enabled = false;
        yield return new WaitForSeconds(seconds);
        rend.enabled = true;
        rend.enabled = false;
        yield return new WaitForSeconds(seconds);
        rend.enabled = true;
        rend.enabled = false;
        yield return new WaitForSeconds(seconds);
        rend.enabled = true;
        rend.enabled = false;
        yield return new WaitForSeconds(seconds);
        rend.enabled = true;
    }
}