using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public float health = 10;
    public float seconds = 0.04f;
    public int life = 3;

    bool isHit = false;

    public Text showHealth;

    // Use this for initialization
    void Start()
    {
        ShowHealth();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DamageTaken(float damage)
    {
        if (!isHit)
        {
            isHit = true;
            if (health > 0)
            {
                health -= damage;
                ShowHealth();
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
    }

    void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel); //Wir nehmen ersmal das hier -> Licht geht nicht aus beim Restart

        //SceneManager.LoadScene("main", LoadSceneMode.Single);


        //UnityEngine.SceneManagement.SceneManager.LoadScene();
    }

    IEnumerator DamageEffect()
    {
        Renderer rend = GetComponent<Renderer>();
        for (int i = 3; i > 0; i--) //Schleife fürs Blinken bei Schaden
        {
            rend.enabled = false;
            yield return new WaitForSeconds(seconds);
            rend.enabled = true;
            yield return new WaitForSeconds(seconds);
        }
        isHit = false;
    }

    void ShowHealth()
    {
        showHealth.text = "Leben: " + health;
    }
}