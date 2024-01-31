using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingCreator : MonoBehaviour
{
    // rotatingCreator is a script attached to a blank object which rotates, and creates rotating drones, rotating drones' movements is done by otomaticly in this script

    [SerializeField] float firstCreateTime;
    [SerializeField] float createDelay;

    Vector3 startPosition;

    poolMechanism poolMech;

    // [SerializeField] private float rotationSpeed; // rotate around itself

    void Start()
    {
        poolMech = FindObjectOfType<poolMechanism>();
        InvokeRepeating("CreateObject", firstCreateTime, createDelay);

    }

    void CreateObject()
    {
        poolMech.dequeue(gameObject);
    }

    void Update()
    {
        //transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime); // rotate around itself
    }

    // Start is called before the first frame update
    void OnEnable()
    {
        transform.position = new Vector3(0, 0, 0);
        transform.GetChild(0).transform.position = new Vector3(Random.Range(-100, -60), Random.Range(10, 25), 0);
    }

}
