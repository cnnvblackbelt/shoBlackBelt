using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animatorClip;

    private Rigidbody rigidBody;
    private BoxCollider myCollider;
    [SerializeField]
    public bool onGround;
    public float distanceToGround;
    private Quaternion lastLook;

    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        rigidBody = GetComponent<Rigidbody>();
        animatorClip = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider>();
        distanceToGround = myCollider.bounds.extents.y;
        lastLook = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float vy = rigidBody.velocity.y;

        // check to see if Codey is on the ground
        if (vy < 0.5f && vy > -0.5f && Physics.Raycast(transform.position, -Vector3.up, distanceToGround))
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }

        // rotate Codey
        //if (horizontal > 0)
        //{
        //    transform.rotation = Quaternion.Euler(0, 90, 0);
        //}
        //else if (horizontal < 0)
        //{
        //    transform.rotation = Quaternion.Euler(0, 270, 0);
        //}
        Vector3 movementVector = new Vector3(horizontal, 0, vertical).normalized;
        
        if (movementVector.magnitude != 0)
        {
            lastLook = Quaternion.LookRotation(movementVector);
        }
        transform.rotation = lastLook;

        // update animator
        float verticalVelocity = rigidBody.velocity.y;
        if (onGround)
        {
            verticalVelocity = 0;
        }
       
        animatorClip.SetFloat("horizontalVector", movementVector.magnitude);
        animatorClip.SetFloat("verticalVector", verticalVelocity);

    }

}
