using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lean_script : MonoBehaviour
{
    Quaternion initialRotation; //nom
    [SerializeField] float amt, slerpAmt;//nom
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = transform.localRotation; //nom
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Debug.Log("leaningg");
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
            transform.localRotation = Quaternion.Slerp(transform.localRotation, initialRotation, Time.deltaTime * slerpAmt);
        }
    }
}
