using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_drone : MonoBehaviour
{
    //[SerializeField]
    bool changePosition = false;

    Vector3 startPosition;
    Vector3 endPosition;
    float desiredDuration = 1.5f;
    float elapsedTime = 0;

    bool startEndDetermined = false;


    void Start()
    {
        startPosition = new Vector3(Random.Range(5, 40), Random.Range(13, 25), Random.Range(25, 45));
        gameObject.transform.position = startPosition;
    }

    public void changePosBool(bool boole)
    {
        //if (boole) Debug.Log("changePos is true");
        changePosition = boole;
    }

    void startEndUpdater()
    {

        startPosition = transform.position;
        if (transform.position.x < 0)
        {
            endPosition = new Vector3(Random.Range(5, 40), Random.Range(13, 25), Random.Range(25, 45));
           // Debug.Log("random num 1");
        }
        else
        {
            endPosition = new Vector3(Random.Range(-40, -5), Random.Range(13, 25), Random.Range(25, 45));
           // Debug.Log("raddom num 2");
        }

    }
    void Update()
    {
        if (changePosition)
        {
            startEndUpdater();
            startEndDetermined = true;
            changePosition = false;
        }
        if (startEndDetermined)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

            if (Mathf.Abs(transform.position.x - endPosition.x) <= 0.1)
            {
                elapsedTime = 0;
                startEndDetermined = false;
            }
        }
    }

}