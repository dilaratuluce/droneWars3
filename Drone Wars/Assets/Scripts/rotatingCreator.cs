using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingCreator : MonoBehaviour
{
    // rotatingCreator is a script attached to a blank object which rotates, and creates rotating drones, rotating drones' movements is done by otomaticly in this script
    [SerializeField] private float rotationSpeed; // rotate around itself

    [SerializeField] private GameObject rotatingPrefab;
    [SerializeField] float firstCreateTime;
    [SerializeField] float createDelay;

    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateObject", firstCreateTime, createDelay);
        
    }

    void CreateObject()
    {
        var newObj = Instantiate(rotatingPrefab, transform.position, Quaternion.identity);
        newObj.transform.parent = gameObject.transform;
        startPosition = new Vector3(Random.Range(-95, -30), Random.Range(10, 25), 0);
        newObj.transform.position = startPosition;
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime); // rotate around itself
    }

}
