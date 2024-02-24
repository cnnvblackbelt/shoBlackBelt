using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHazard : MonoBehaviour
{
    public float speed = 7f;
    public GameObject player;
    public Text scoreText;
    public PlayerFire check;

    private Vector3 targetPosition;

    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(SelfDestruct());
        targetPosition = player.transform.position - transform.position;
        check = GameObject.Find("Player").GetComponent<PlayerFire>();
    }

    void Update()
    {
        transform.position += targetPosition.normalized * speed * Time.deltaTime;

        if (check.getBombPower())
        {
            Debug.Log("Enemies are destroyed");
            Destroy(gameObject);
            //  check.resetBombPower();
        }
    }


    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

}
