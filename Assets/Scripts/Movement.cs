using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Lives")]
    public int lives;

    public GameObject player;
    [Header("Movement")]
    [Tooltip("Speed of movement")]
    public float speed;
    public enum MovementType
    {
        AllDirections,
        HorizontalOnly,
        VerticalOnly
    }

    [SerializeField]
    private MovementType movementType = 0;

    [Header("Platform Movement")]
    [Tooltip("Adjusts Movement for Platform Games")]
    public bool platformSettings = false;
    public bool WASD = false;


    private float masterSpeed;

    void Awake()
    {
        masterSpeed = speed;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (platformSettings)
        {
            Rigidbody rigidBody;
            rigidBody = GetComponent<Rigidbody>();
            float verticalMovement = rigidBody.velocity.y;
            if (verticalMovement != 0)
            {
                speed = masterSpeed / 3;
            }
            else
            {
                speed = masterSpeed;
            }
        }
        if(lives > 0){
            switch (movementType)
            {
                case MovementType.HorizontalOnly:
                    vertical = 0f;
                    break;
                case MovementType.VerticalOnly:
                    horizontal = 0f;
                    break;
            }
        }

        if (WASD)
        {
            horizontal = Input.GetAxis("Horizontal2");
            vertical = Input.GetAxis("Vertical2");
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0);

        transform.position += movement * Time.fixedDeltaTime * speed;
    }
}
