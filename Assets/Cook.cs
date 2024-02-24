using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cook : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Prefabs")]
    public GameObject breadPrefab;
    public GameObject eggPrefab;
    public GameObject platePrefab;
    public GameObject orangePrefab;
    public GameObject mugPrefab;

    [Header("Meals")]
    public GameObject eggToastMeal;
    public GameObject orangeToastMeal;
    public GameObject coffeeMeal;

    [Header("Kitchen Objects")]
    public Stove stove;
    public CoffeeBar coffeeBar;

    [Header("Codey's Inventory")]
    public GameObject holdingItem;

    [Header("Sounds")]
    public AudioSource trashNoise;
    public AudioSource placeNoise;
    public AudioSource pickupNoise;

    [Header("UI Stuff")]
    public string triggerName = "";
    public string itemName = "";
    public Text stationLabel;
    public Text timerLabel;
    public Text inventoryLabel;
    public Text messageLabel;

    private int mealsCooked = 0;

    // Update is called once per frame
    void Update()
    {
        if (mealsCooked < 7)
        {
            timerLabel.text = Time.timeSinceLevelLoad.ToString();
        } else
        {
            messageLabel.text = "Good Job! Press A or Space to reset!";
            if (Input.GetButtonDown("Pick Up"))
            {
                SceneManager.LoadScene(0);
            }
        }
        if (Input.GetButtonDown("Pick Up"))
        {
            // if Codey is not holding an item
            if (holdingItem == null)
            {
                // First check where Codey is, then pick up the item
                if (triggerName == "Bread")
                {
                    PickUpItem("bread", breadPrefab);
                }
                if (triggerName == "Egg")
                {
                    PickUpItem("egg", eggPrefab);
                }
                if (triggerName == "Plates")
                {
                    PickUpItem("plate", platePrefab);
                }
                if (triggerName == "Orange")
                {
                    PickUpItem("orange slices", orangePrefab);
                }
                if (triggerName == "Mug")
                {
                    PickUpItem("mug", mugPrefab);
                }
                // stove is a little more complicated
                if (triggerName == "Stove")
                {
                    // Codey can't do anything if the stove isn't done or if it doesn't have a food item
                    if (stove.isCooking) return;
                    if (stove.cookedFoodObject == null) return;
                    // get the food item that's been cooked
                    // ask the stove what the name is and for the object
                    PickUpItem(stove.cookedFoodName, stove.cookedFoodObject);
                    // ask the stove to clean itself up
                    stove.FoodPickup();
                }
                if (triggerName == "Coffee Bar")
                {
                    if (coffeeBar.isBrewing) return;
                    if (coffeeBar.brewedCoffeeObject == null) return;
                    PickUpItem("filled mug", coffeeBar.brewedCoffeeObject);
                    coffeeBar.FoodPickup();
                }
            }
            if (holdingItem != null)
            {
                if (triggerName == "Trash")
                {
                    trashNoise.Play();
                    placeNoise.enabled = false;
                    PlaceHeldItem();
                    placeNoise.enabled = true;
                }
                if (triggerName == "Stove")
                {
                    if (stove.isCooking) return;
                    if (itemName == "egg")
                    {
                        PlaceHeldItem();
                        stove.FryEgg();
                    }
                    if (itemName == "bread")
                    {
                        PlaceHeldItem();
                        stove.ToastBread();
                    }
                }
                if (triggerName == "Coffee Bar")
                {
                    if (coffeeBar.isBrewing) return;
                    if (itemName == "mug")
                    {
                        PlaceHeldItem();
                        coffeeBar.BrewCoffee();
                    }
                }
                if (triggerName == "Egg Toast")
                {
                    PlaceMeal(eggToastMeal.transform.Find(itemName).gameObject);
                }
                if (triggerName == "Orange Toast")
                {
                    PlaceMeal(orangeToastMeal.transform.Find(itemName).gameObject);
                }
                if (triggerName == "Coffee")
                {
                    PlaceMeal(coffeeMeal.transform.Find(itemName).gameObject);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        
    }
    private void PlaceHeldItem()
    {
        placeNoise.Play();
        Destroy(holdingItem);
        inventoryLabel.text = "";
        itemName = "";
    }

    private void PlaceMeal(GameObject meal)
    {
        if (!meal.activeInHierarchy)
        {
            meal.SetActive(true);
            PlaceHeldItem();
            mealsCooked += 1;
        }
    }
    private void PickUpItem(string name, GameObject item)
    {
        pickupNoise.Play();
        itemName = name;
        inventoryLabel.text = itemName;
        holdingItem = Instantiate(item, transform, false);
        holdingItem.transform.localScale = new Vector3(3, 3, 3);
        holdingItem.transform.localPosition = new Vector3(0, 2, 2);
    }

    private void OnTriggerEnter(Collider other)
    {
        triggerName = other.name;
        stationLabel.text = triggerName;
    }
    private void OnTriggerExit(Collider other)
    {
        triggerName = "";
        stationLabel.text = "";
    }
    private void OnTriggerStay(Collider other)
    {
        triggerName = other.name;
        stationLabel.text = triggerName;
    }
}
