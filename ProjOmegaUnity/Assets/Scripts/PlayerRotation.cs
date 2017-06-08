using UnityEngine;
using System.Collections;

public class PlayerRotation : MonoBehaviour
{

    // How fast your object moves
    private float moveSpeed;
    // How fast your object will rotate in the direction of movement
    public float rotationSpeed;
    private Vector3 previousLocation;
    private Vector3 currentLocation;
    private Vector3 rotPosition;

    public Transform camTransform;

    // Use this for initialization
    void Start()
    {

        moveSpeed = 100;
        //rotationSpeed = 5;

    }


    // Update is called once per frame
    void Update()
    {

        previousLocation = currentLocation;
        //currentLocation = transform.position;
        currentLocation = rotPosition;
        if (Input.GetKey("w") && Input.GetKey("a"))
        {
            currentLocation.z += moveSpeed * Time.fixedDeltaTime;
            currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
            //transform.position = currentLocation;
            rotPosition = currentLocation;


            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(camTransform.forward - camTransform.right), Time.fixedDeltaTime * rotationSpeed);
            transform.rotation = newRotation;
            transform.Rotate(-newRotation.eulerAngles.x, 0, -newRotation.eulerAngles.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);

        }
        else if (Input.GetKey("w") && Input.GetKey("d"))
        {
            currentLocation.z += moveSpeed * Time.fixedDeltaTime;
            currentLocation.x += moveSpeed * Time.fixedDeltaTime;
            rotPosition = currentLocation;

            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(camTransform.forward + camTransform.right), Time.fixedDeltaTime * rotationSpeed);
            transform.rotation = newRotation;
            transform.Rotate(-newRotation.eulerAngles.x, 0, -newRotation.eulerAngles.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);

        }
        else if (Input.GetKey("a") && Input.GetKey("s"))
        {
            currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
            currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
            rotPosition = currentLocation;

            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-camTransform.right - camTransform.forward), Time.fixedDeltaTime * rotationSpeed);
            transform.rotation = newRotation;
            transform.Rotate(-newRotation.eulerAngles.x, 0, -newRotation.eulerAngles.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);

        }
        else if (Input.GetKey("s") && Input.GetKey("d"))
        {
            currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
            currentLocation.x += moveSpeed * Time.fixedDeltaTime;
            rotPosition = currentLocation;

            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(camTransform.right - camTransform.forward), Time.fixedDeltaTime * rotationSpeed);
            transform.rotation = newRotation;
            transform.Rotate(-newRotation.eulerAngles.x, 0, -newRotation.eulerAngles.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);

        }
        else if (Input.GetKey("w"))
        {
            currentLocation.z += moveSpeed * Time.fixedDeltaTime;
            rotPosition = currentLocation;
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(camTransform.forward.x, camTransform.forward.y, camTransform.transform.forward.z)), Time.fixedDeltaTime * rotationSpeed);
            transform.rotation = newRotation;
            transform.Rotate(-newRotation.eulerAngles.x,0,-newRotation.eulerAngles.z);
            /*
            if (newRotation.eulerAngles.y > 0)
                transform.Rotate(0, -newRotation.eulerAngles.y, 0);
            else if (newRotation.eulerAngles.y < 0)
                transform.Rotate(0, newRotation.eulerAngles.y, 0);
            */  

            //transform.rotation = Quaternion.Euler(0, newRotation.eulerAngles.y, newRotation.eulerAngles.z);
            //transform.rotation = Quaternion.LookRotation(new Vector3(0f,newRotation.y,newRotation.z).normalized);
            //transform.Rotate(0,newRotation.y,newRotation.z);
            //transform.rotation = new Quaternion(0, newRotation.y,newRotation.z,newRotation.w);
        }
        else if (Input.GetKey("a"))
        {
            currentLocation.x -= moveSpeed * Time.fixedDeltaTime;
            rotPosition = currentLocation;

            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(-camTransform.right.x, -camTransform.right.y, -camTransform.transform.right.z)), Time.fixedDeltaTime * rotationSpeed);
            transform.rotation = newRotation;
            transform.Rotate(-newRotation.eulerAngles.x, 0, -newRotation.eulerAngles.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);

        }
        else if (Input.GetKey("s"))
        {
            currentLocation.z -= moveSpeed * Time.fixedDeltaTime;
            rotPosition = currentLocation;

            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(-camTransform.forward.x, -camTransform.forward.y, -camTransform.transform.forward.z)), Time.fixedDeltaTime * rotationSpeed);
            transform.rotation = newRotation;
            transform.Rotate(-newRotation.eulerAngles.x, 0, -newRotation.eulerAngles.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);

        }
        else if (Input.GetKey("d"))
        {
            currentLocation.x += moveSpeed * Time.fixedDeltaTime;
            rotPosition = currentLocation;

            Quaternion newRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(camTransform.right.x, camTransform.right.y, camTransform.transform.right.z)), Time.fixedDeltaTime * rotationSpeed);
            transform.rotation = newRotation;
            transform.Rotate(-newRotation.eulerAngles.x, 0, -newRotation.eulerAngles.z);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(rotPosition - previousLocation), Time.fixedDeltaTime * rotationSpeed);

        }

    }
}
