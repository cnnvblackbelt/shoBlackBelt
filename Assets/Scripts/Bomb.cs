using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public ParticleSystem Explode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * Time.deltaTime * 5;
        if (transform.position.y <= -30)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Explode.Play();
            Invoke("RemoveExplosion", 0.7f);
        }
    }
    void RemoveExplosion()
    {
        Destroy(gameObject);
    }
}
