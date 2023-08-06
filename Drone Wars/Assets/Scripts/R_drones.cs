using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class R_drones : MonoBehaviour
{
    // R_drones script instantiates running drones and running drones' move is coded in RunnningDrone script

    //[SerializeField] private GameObject runningPrefab;
    [SerializeField] float firstCreateTime;
    [SerializeField] float createDelay;

    //[SerializeField] GameObject parentObject;

    //manager health;

    poolMechanism poolMech;

    void Start()
    {
        poolMech = FindObjectOfType<poolMechanism>();
        InvokeRepeating("CreateObject", firstCreateTime, createDelay);
    }

    void CreateObject()
    {
        //Instantiate(runningPrefab, transform.position, Quaternion.identity);

        poolMech.dequeue(gameObject);
        Debug.Log("dequeue invoked");

    }

}
