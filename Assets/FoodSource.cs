using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSource : MonoBehaviour
{
    public GameObject foodItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject getFoodItem()
    {
        return foodItem;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}
