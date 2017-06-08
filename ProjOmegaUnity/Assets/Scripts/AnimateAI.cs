using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateAI : MonoBehaviour {

    public float speed;

    private float speedCopy;

    public float increasedSpeed;

    public float currentIncreasedSpeed;

    private Vector3 targetPosition;

    Rigidbody playerObject;

    //CharacterController playerObject;
    Animator anim;

    private bool isMoving;
    private bool isRunning;
    void Start()
    {
        playerObject = GetComponent<Rigidbody>();
        //playerObject = GetComponent<CharacterController>();
        speedCopy = speed;
        isMoving = false;
        anim = GetComponent<Animator>();
        //currentIncreasedSpeed = increasedSpeed;
        currentIncreasedSpeed = 0;
    }


    void Update()
    {
        checkForMovement();
        checkJump();
    }

    void checkForMovement()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            isMoving = true;
            //anim.SetBool("walking", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("walking", false);
                anim.SetBool("running", true);
                currentIncreasedSpeed = increasedSpeed;
            }
            else
            {
                anim.SetBool("walking", true);
                anim.SetBool("running", false);
                currentIncreasedSpeed = 0;
            }
        }
        else
        {
            isMoving = false;
            anim.SetBool("walking", false);
            anim.SetBool("running", false);
        }
    }

    void checkJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            jump();
        }
    }

    void FixedUpdate()
    {
        if (isMoving)
            MovePlayer();
    }

    void MovePlayer()
    {
        //playerObject.SimpleMove();
        playerObject.AddForce(transform.forward * (speed + currentIncreasedSpeed), ForceMode.Force);
    }

    void jump()
    {
        playerObject.velocity = new Vector3(0f, 9f, 0f);
    }

}
