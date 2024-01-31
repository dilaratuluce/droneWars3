using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// problem şu ki bu RunnignDrone pasive edilip aktif edildiğinde hareketine KALDIĞI YERDEN devam ediyor


public class RunningDrone : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    [SerializeField] float desiredDuration;
    float elapsedTime;

    [SerializeField] private AnimationCurve curve; // you can change the animation curve in Unity

    poolMechanism poolMech;

    public GameObject parentObject;


    void Start()
    {

    }
    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();

        Invoke("Destroy", desiredDuration);

        startPosition = new Vector3(gameParameters.runnig_drone_x, Random.Range(gameParameters.runnig_drone_y1, gameParameters.runnig_drone_y2), Random.Range(gameParameters.runnig_drone_z1, gameParameters.runnig_drone_z2));
        //transform.position = startPosition;
        transform.position = new Vector3(-100, 15, 40);
        Debug.Log("working here");
        endPosition = new Vector3(130, transform.position.y, transform.position.z);
        elapsedTime = 0;

    }

    void Destroy()
    {
        startPosition = new Vector3(gameParameters.runnig_drone_x, Random.Range(gameParameters.runnig_drone_y1, gameParameters.runnig_drone_y2), Random.Range(gameParameters.runnig_drone_z1, gameParameters.runnig_drone_z2));
        transform.position = startPosition;
        poolMech.enqueue(gameObject, parentObject);
    }


    void Update()
    {
        
         elapsedTime += Time.deltaTime;
         float percentageComplete = elapsedTime / desiredDuration;

         transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));

            /*if(transform.position.x >= 120) //localposition? if problem, use coroutine here instead of enqueue with location enqueue with time
            {
                //Destroy(this.gameObject);
                //Debug.Log("came here");
                startPosition = new Vector3(-100, Random.Range(10, 25), Random.Range(20, 50)); //
                transform.position = startPosition;
                poolMech.enqueue(gameObject);
            }*/
        


    }
}
