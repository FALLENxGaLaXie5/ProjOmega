using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private float speedCopy;

    public float increasedSpeed;

    private Vector3 targetPosition;

    Rigidbody playerObject;

    Animator anim;

    private bool isMoving;
    private bool isRunning;
    void Start()
    {
        playerObject = GetComponent<Rigidbody>();
        speedCopy = speed;
        isMoving = false;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        checkForMovement();
    }

    void checkForMovement()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            isMoving = true;
            anim.SetBool("walking", true);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("running", true);
                increasedSpeed = 10;
            }
            else
            {
                anim.SetBool("running", false);
                increasedSpeed = 0;
            }
        }
        else
        {
            isMoving = false;
            anim.SetBool("walking", false);
        }
    }

    void FixedUpdate()
    {
        if(isMoving)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        playerObject.AddForce(transform.forward * (speed + increasedSpeed));
    }


}
