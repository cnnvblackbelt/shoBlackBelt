using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public string itemName = "";
    public GameObject heldItem;
    public FoodSource foodSource;
    public 
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Pick Up"))
        {
            if (heldItem == null)
            {
                PickUpItem();
            }
            else
            {
                PlaceItem();
            }
        }


    }

    private void PickUpItem()
    {
        if (foodSource != null)
        {
            heldItem = foodSource.getFoodItem();
        }
    }
    private void PlaceItem()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        foodSource = other.GetComponent<FoodSource>();
    }
    private void OnTriggerExit(Collider other)
    {
        foodSource = null;
    }
}
