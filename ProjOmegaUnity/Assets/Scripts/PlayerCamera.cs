using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour
{
    //target will be the player position
    public Transform target;

    //distance from player
    public float distance;

    public int rayDistance = 50;

    Transform mockCamera;
    Transform mockCamera1;
    bool mockCameraRepositioned = false;
    bool foundNewPosition = false;

    /**
        Update is called at the beginning of every frame at run time.
        This means that all runnable code is ran at one point or another from here.
        Similar to main or runnable with frame by frame implementation.
        Update will change the camera's position to reflect the player's position
            WITHOUT reflecting the player's rotation and MAINTAINING a constant z offset.
    */

    void Start()
    {
        mockCamera = this.gameObject.transform;
        mockCamera1 = this.gameObject.transform;
    }

    void Update()
    {
        /*
        RaycastHit hit;
        Ray landingRay = new Ray(transform.position, this.gameObject.transform.forward);
        Debug.DrawRay(transform.position, this.gameObject.transform.forward * rayDistance);
        if(Physics.Raycast(landingRay, out hit, rayDistance))
        {
            if (hit.collider.tag != "Player")
            {
                if (!foundNewPosition)
                    findNewCameraPosition();
                else
                    moveToNewPosition();
            }
            else
                transform.position = new Vector3(target.position.x, target.position.y + distance, target.position.z - (distance * 1.5f));
           
        }
        */
        transform.position = new Vector3(target.position.x, target.position.y + distance, target.position.z - (distance * 1.5f));
    }

    void findNewCameraPosition()
    {
        Debug.Log("PLAYA OUTA SIGHT!!");
        //bool foundPosition = false;
        if(!mockCameraRepositioned)
        {
            mockCameraRepositioned = true;
            mockCamera = this.gameObject.transform;
            mockCamera1 = this.gameObject.transform;
        }
        while(!foundNewPosition)
        {
            mockCamera.transform.LookAt(target);
            mockCamera1.transform.LookAt(target);
            mockCamera.transform.position = new Vector3(target.position.x, target.position.y + distance, target.position.z - (distance * 1.5f));
        }

        //transform.LookAt(target);
    }

    void moveToNewPosition()
    {
        transform.LookAt(target);
    }
}
