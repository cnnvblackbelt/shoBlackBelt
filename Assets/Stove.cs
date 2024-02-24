using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject stoveEgg;
    public GameObject stoveToast;
    public ParticleSystem smoke;
    public ParticleSystem done;
    public bool isCooking = false;
    public string cookedFoodName = "";
    public GameObject cookedFoodObject;
    public AudioSource chime;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FryEgg()
    {
        stoveEgg.SetActive(true);
        smoke.Play();
        isCooking = true;
        cookedFoodName = "fried egg";
        cookedFoodObject = stoveEgg;
        Invoke("CompleteCooking", 6f);
    }
    public void ToastBread()
    {
        stoveToast.SetActive(true);
        smoke.Play();
        isCooking = true;
        cookedFoodName = "toast";
        cookedFoodObject = stoveToast;
        Invoke("CompleteCooking", 8f);
    }
    public void CompleteCooking()
    {
        chime.Play();
        smoke.Stop();
        done.Play();
        isCooking = false;
    }
    public void FoodPickup()
    {
        done.Stop();
        stoveEgg.SetActive(false);
        stoveToast.SetActive(false);
        cookedFoodObject = null;
        cookedFoodName = "";
    }
}
