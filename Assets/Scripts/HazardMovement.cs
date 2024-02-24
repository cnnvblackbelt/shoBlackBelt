using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HazardMovement : MonoBehaviour
{
    [Header("Text object")]
    public Score score;

    

    private void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<Score>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 10;
        if (transform.position.y >= 30)
        {
            Destroy(gameObject);
        }

        

    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            score.AddToScore(100);
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "EnemyBlast")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Debug.Log("something");
        }

    }
}
