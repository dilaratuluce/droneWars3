using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_drones : MonoBehaviour
{
    [SerializeField] private GameObject runningPrefab;
    [SerializeField] float firstCreateTime;
    [SerializeField] float createDelay;

    manager health;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateObject", firstCreateTime, createDelay);      
    }
    void CreateObject()
    {
        Instantiate(runningPrefab, transform.position, Quaternion.identity);
        /*if (runningPrefab.tag.Equals("health_drone") && health.getHealth()<=50)
        {
            Instantiate(runningPrefab, transform.position, Quaternion.identity);
        }
        else if (!runningPrefab.tag.Equals("health_drone"))
        {
            Instantiate(runningPrefab, transform.position, Quaternion.identity);
        }*/

    }

}
