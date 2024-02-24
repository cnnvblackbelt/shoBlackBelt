using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyStar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -30)
        {
            Destroy(gameObject);
        }
    }
}
