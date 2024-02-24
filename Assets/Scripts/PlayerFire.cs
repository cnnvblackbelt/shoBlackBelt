using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerFire : MonoBehaviour
{
    [Header("Text object")]
    public Text text;

    [Header("Lives")]
    public int myLives;

    [Header("Text object")]
    public Score score;

    public GameObject Blast;
    public int highScore;
    public int newScore;
    public ParticleSystem Explosion;
    public ParticleSystem SmallExplosion;
    public ParticleSystem Warning;
    public ParticleSystem Heal;
    public bool bombPower;


    float cooldown = 0.14f;
    bool inCooldown = false;

    float powerUpCoolDown = 0.14f;
    bool inPowerCooldown = false;
    public bool WASD = false;
    public bool TwoPlayer = false;



    void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
        bombPower = false;
      
    }

    void Update()
    {
        if (WASD == true && Input.GetKey("space") && !inCooldown)
        {
            Instantiate(Blast, transform.position, transform.rotation);
            inCooldown = true;
        }
        else
        if(WASD == false && Input.GetKey("right shift") && !inCooldown)
        {
            Instantiate(Blast, transform.position, transform.rotation);
            inCooldown = true;

        }

        if (inCooldown)
        {
            cooldown -= Time.deltaTime;
            if (cooldown <= 0)
            {
                cooldown = 0.14f;
                inCooldown = false;
            }
            
        }


        if (inPowerCooldown)
        {
            powerUpCoolDown -= Time.deltaTime;
            if (powerUpCoolDown <= 0)
            {
                powerUpCoolDown = 0.14f;
                inPowerCooldown = false;
                bombPower = false;
            }

        }
        if (myLives == 0)
        {
            Explosion.Play();
            Invoke("GAMEOVER", 0.3f);
        }
        if (myLives == 1)
        {
            Warning.Play();
        }
        if (myLives > 1)
        {
            Warning.Stop();
        }

    }


    void OnCollisionEnter(Collision other)
        {

            if (other.gameObject.tag == "EnemyBlast")
            {
                Destroy(other.gameObject);
                myLives -= 1;
                text.text = "Lives: " + myLives;
                SmallExplosion.Play();
                Invoke("StopExplosion", 1);
            }
            if (other.gameObject.tag == "HealthPower")
            {
                Destroy(other.gameObject);
                myLives += 1;
                text.text = "Lives: " + myLives;
                Heal.Play();
                
            }

        if (other.gameObject.tag == "Enemy")
            {
                //Destroy(other.gameObject);
                myLives -= 1;
                text.text = "Lives: " + myLives;
            }
        if (other.gameObject.tag == "Bomb")
        {
            bombPower = true;
            inPowerCooldown = true;
            Debug.Log("Bomb power is collected");
            //Destroy(other.gameObject);
            //Debug.Log(bombPower);

        }
            
        }
    void StopExplosion()
    {
        SmallExplosion.Stop();
    }
    public bool getBombPower()
    {
        return bombPower;
    }
    public void resetBombPower()
    {
        bombPower = false;
    }

    void GAMEOVER()
    {
        newScore = score.getScore();

        if (PlayerPrefs.HasKey("hiScore"))
        {
            if (score.getScore() > PlayerPrefs.GetInt("hiScore"))
            {
                highScore = newScore;
                PlayerPrefs.SetInt("hiScore", highScore);
                PlayerPrefs.Save();
            }
        }
        else
        {
            if (newScore > highScore)
            {
                highScore = newScore;
                PlayerPrefs.SetInt("hiScore", highScore);
                PlayerPrefs.Save();
            }
        }
        Debug.Log("Highscore" + PlayerPrefs.GetInt("hiScore").ToString());
        Debug.Log("GAMEOVER");
        if (TwoPlayer == true)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(2);

        }
    }
    public int getLives()
    {
        return myLives;
    }
}