using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;
    public GameObject hazard;
    public ParticleSystem Explosion;
    public PlayerFire check;
    float timer;
    bool running = true;
    public float delay = 2f;
    public Score score;


    void Start()
    {
        player = GameObject.Find("Player");
        check = GameObject.Find("Player").GetComponent<PlayerFire>();
        score = GameObject.Find("GameManager").GetComponent<Score>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        timer += Time.deltaTime;

        if (running && timer >= delay)
        {
            InvokeRepeating("Blast", 0, 1f);
            running = false;
        }

       
        if (check.getBombPower())
        {
            Debug.Log("Enemies are destroyed");
            score.AddToScore(100);
            Destroy(gameObject);
          //  check.resetBombPower();
        }   
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            Invoke("DestroyEnemy", 0.15f);
            Explosion.Play();
        }

        if (other.gameObject.CompareTag("Blast"))
        {
            GetComponent<BoxCollider>().enabled = false;
            Invoke("DestroyEnemy", 0.15f);
            Explosion.Play();
        }
    }

    void Blast()
    {
        Vector3 offset = new Vector3(-3, 0, 0);
        Instantiate(hazard, transform.position + offset, transform.rotation);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
