using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{

    public Material StarGlow;
    public float starSize;
    public float starRate;
    private float nextStar;
    public float starSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextStar)
        {
            starSize = Random.Range(0.1f, 0.05f);
            nextStar = Time.time + starRate;
            GameObject star = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            star.transform.parent = gameObject.transform;
            star.transform.position = new Vector3(Random.Range(-27.0f, 27.0f), 17, 5);
            star.transform.localScale = new Vector3(starSize, starSize, starSize);
            star.AddComponent<Rigidbody>();
            star.AddComponent<DestroyStar>();
            star.GetComponent<Renderer>().material = StarGlow;
            star.GetComponent<Rigidbody>().useGravity = false;
            star.GetComponent<Rigidbody>().velocity = new Vector3(0, -starSize * starSpeed, 0);
        }



    }
}
