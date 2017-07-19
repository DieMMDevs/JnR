using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {
    public float health = 10;
    public int life = 3;
    public Vector3 playerposition;
    public float seconds = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DamageTaken(float damage)
    {
        if(health > 0)
        {
            health -= damage;
            if(health <= 0)
            {
                if(life > 0)
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
        Application.LoadLevel(Application.loadedLevel);

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
