using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject HealthPrefab;
    public GameObject BombPrefab;
    public float delay = 3.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);

    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        ResetDelay();
        StartCoroutine(PowerGenerator());

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    IEnumerator PowerGenerator()
    {
        yield return new WaitForSeconds(delay);
        if (active)
        {
            float randomX1 = Random.Range(screenBounds.x - objectWidth, screenBounds.x * -1 + objectWidth);
            float randomX2 = Random.Range(screenBounds.x - objectWidth, screenBounds.x * -1 + objectWidth);
            float spawnY = (screenBounds.y + objectHeight) + 20;
            if (Random.Range(1.0f,6.0f) >2.5f)
            {
                Instantiate(HealthPrefab, new Vector3(randomX1, spawnY, 0), HealthPrefab.transform.rotation);
            }
            if (Random.Range(1.0f, 5.0f) > 3.0f)
            {
                Instantiate(BombPrefab, new Vector3(randomX2, spawnY, 0), BombPrefab.transform.rotation);
            }
            
            

            ResetDelay();
        }

        StartCoroutine(PowerGenerator());
    }

    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }

}
