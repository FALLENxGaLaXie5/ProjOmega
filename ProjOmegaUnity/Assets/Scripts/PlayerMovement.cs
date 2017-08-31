using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    private float directionDampTime = 0.25f;


    private float h = 0.0f;
    private float v = 0.0f;



    public float speed = 0.0f;

    public float maxSpeed = 10.0f;
    public float minSpeed = 1.0f;

    private float speedCopy;

    public float speedAnim;

    public float increasedSpeed;



    public float currentIncreasedSpeed;

    private Vector3 targetPosition;

    Rigidbody playerObject;

    //CharacterController playerObject;

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
        speedAnim = 1.0f;
    }
    //lolololol

    void Update()
    {
        if (anim)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            if (h != 0.0f || v != 0.0f)
            {
                speed = 0.5f;
            }
            speed = new Vector2(h, v).sqrMagnitude;
            anim.SetFloat("Speed", speed);
            anim.SetFloat("Direction", h, directionDampTime, Time.deltaTime);

        }

        //checkForMovement();
        //checkJump();
    }

    /*
    void checkForMovement()
    {
        if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("a") || Input.GetKey("d"))
        {
            isMoving = true;
            //anim.SetBool("walking", true);

            if(Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("walking", false);
                anim.SetBool("running", true);
                currentIncreasedSpeed = increasedSpeed;
                anim.SetFloat("Speed", speedAnim);
                LerpAnimSpeedUp();
            }
            else if(speedAnim > 1.5f)
            {
                anim.SetFloat("Speed", speedAnim);
                LerpAnimSpeedDown();
            }
            else if (speedAnim > 1.0f)
            {
                anim.SetBool("walking", true);
                anim.SetBool("running", false);
                LerpAnimSpeedDown();
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

    */

    void LerpAnimSpeedUp()
    {
        speedAnim = Mathf.Lerp(speedAnim, maxSpeed, Time.deltaTime * 0.5f);
    }

    void LerpAnimSpeedDown()
    {
        speedAnim = Mathf.Lerp(speedAnim, minSpeed, Time.deltaTime * 1.0f);
    }

    void checkJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("jump");
            jump();
        }
    }

    void FixedUpdate()
    {
        /*
        if(isMoving)
            MovePlayer();
        */
    }

    void MovePlayer()
    {
        //playerObject.SimpleMove();
        playerObject.AddForce(transform.forward * (speed + currentIncreasedSpeed),ForceMode.Force);
    }

    void jump()
    {
        playerObject.velocity = new Vector3(0f, 9f, 0f);
    }

}
