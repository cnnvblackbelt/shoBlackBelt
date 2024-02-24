using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeBar : MonoBehaviour
{
    public GameObject coffeeBarMug;
    public ParticleSystem smoke;
    public ParticleSystem done;
    public bool isBrewing = false;
    public GameObject brewedCoffeeObject;
    public AudioSource chime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BrewCoffee()
    {
        coffeeBarMug.SetActive(true);
        smoke.Play();
        isBrewing = true;
        Invoke("CompleteBrewing", 12f);
    }
    private void CompleteBrewing()
    {
        chime.Play();
        smoke.Stop();
        done.Play();
        brewedCoffeeObject = coffeeBarMug;
        isBrewing = false;
    }
    public void FoodPickup()
    {
        done.Stop();
        coffeeBarMug.SetActive(false);
        brewedCoffeeObject = null;
    }
}
