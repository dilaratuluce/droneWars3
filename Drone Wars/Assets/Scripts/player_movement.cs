using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class Player_movement : MonoBehaviour
{
    CharacterController characterController;
    Vector3 move_direction;
    [SerializeField] float speed;

    bool isCrouching = false; // crouching code starts
    Vector3 crouchScale; ///= new Vector3(2, 1, 2);
    Vector3 startScale;
    float crouchDuration = 0.3f;
    float elapsedTime; // crounhing code ends


    private void Awake()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        move_direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        move_direction = transform.TransformDirection(move_direction);
        float currentSpeed = speed;
        move_direction *= currentSpeed * Time.deltaTime;
        characterController.Move(move_direction);
        Vector3 currentPosition = transform.position;
        transform.position = currentPosition;

        
        if (Input.GetKeyDown(KeyCode.C)) // crouching code starts
        {
            elapsedTime = 0;
            isCrouching = true;
            Debug.Log("crouncing");
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            elapsedTime = 0;
            isCrouching = false;
            Debug.Log("not crouncing");
        }
        if (isCrouching)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / crouchDuration;

            startScale = new Vector3(transform.position.x, 2, transform.position.z);
            crouchScale = new Vector3(transform.position.x, 1, transform.position.z);
            transform.position = Vector3.Lerp(startScale, crouchScale, percentageComplete);
        }
        else if (!isCrouching)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / crouchDuration;

            startScale = new Vector3(transform.position.x, 2, transform.position.z);
            crouchScale = new Vector3(transform.position.x, 1, transform.position.z);
            transform.position = Vector3.Lerp(crouchScale, startScale, percentageComplete); // crouching code ends
        }

        /*if (Input.GetKey(KeyCode.Q))
        {
            Quaternion newRot = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z + amt);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, newRot, Time.deltaTime * slerpAmt);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            Quaternion newRot = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, transform.localRotation.z - amt);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, newRot, Time.deltaTime * slerpAmt);
        }
        else
        {
            transform.localRotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * slerpAmt);
        }*/

        /*Bend.localRotation = Quaternion.Euler(0,0,zRot);
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("bending");
            zRot = Mathf.Lerp(zRot, 15.0f, 5f * Time.deltaTime);
            isRotate = true;
        }
        if (Input.GetKey(KeyCode.E))
        {
            Debug.Log("bending");
            zRot = Mathf.Lerp(zRot, -15.0f, 5f * Time.deltaTime);
            isRotate = true;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            Debug.Log("not bending");
            isRotate = false;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Debug.Log("not bending");
            isRotate = false;
        }
        if (!isRotate)
        {
            zRot = Mathf.Lerp(zRot,0.0f, 5f * Time.deltaTime);
        }*/
    }
}