using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombDrone : MonoBehaviour
{
    //bomb drone has 5 consecutive lerps named round1, round2, round3, round4, round5

    //lerp variables:
    Vector3 startPosition; 
    Vector3 endPosition;
    float desiredDuration = 5f;
    float elapsedTime;

    bool comingToRight;

    bool round1, round2, round3, round4, round5;
    Vector3 destroyPosition;

    poolMechanism poolMech;
    public GameObject parentObject;


    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();

        startPosition = new Vector3(-100, Random.Range(30, 50), Random.Range(10, 25));
        transform.position = startPosition;

        endPosition = new Vector3(Random.Range(gameParameters.bomb_drone_x1, gameParameters.bomb_drone_x2), Random.Range(gameParameters.bomb_drone_y1, gameParameters.bomb_drone_y2), Random.Range(gameParameters.bomb_drone_z1, gameParameters.bomb_drone_z2));

        elapsedTime = 0;
        comingToRight = true;
        round1 = true;
        round2 = round3 = round4 = round5 = false;

    }

    void Update()
    {
        if (comingToRight && (round1 || round3)) // drone is moving right
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

            if (Mathf.Abs(transform.position.y - endPosition.y) <= gameParameters.bomb_drone_abs_limit) // localPosition??
            {
                comingToRight = false;
                startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                endPosition = new Vector3(Random.Range(-gameParameters.bomb_drone_x1, -gameParameters.bomb_drone_x2), Random.Range(gameParameters.bomb_drone_y1, gameParameters.bomb_drone_y2), Random.Range(gameParameters.bomb_drone_z1, gameParameters.bomb_drone_z2));
                elapsedTime = 0;
                if (round1)
                {
                    round1 = false;
                    round2 = true;
                }
                else
                {
                    round3 = false;
                    round4 = true;
                }
            }
        }
        else if(!comingToRight && (round2 || round4)) // drone is moving left
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
            if (Mathf.Abs(transform.position.y - endPosition.y) <= gameParameters.bomb_drone_abs_limit)
            {
                comingToRight = true;
                startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                endPosition = new Vector3(Random.Range(gameParameters.bomb_drone_x1, gameParameters.bomb_drone_x2), Random.Range(gameParameters.bomb_drone_y1, gameParameters.bomb_drone_y2), Random.Range(gameParameters.bomb_drone_z1, gameParameters.bomb_drone_z2));
                elapsedTime = 0;
                if (round2)
                {
                    round2 = false;
                    round3 = true;
                }
                else
                {
                    round4 = false;
                    round5 = true;
                }
            }
        }
        else if(comingToRight && round5) // drone is moving right for the last time, comingToRight is true and it is round5 (last round)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            destroyPosition = new Vector3(140, 10, 25);
            transform.position = Vector3.Lerp(startPosition, destroyPosition, percentageComplete);
            if (Mathf.Abs(transform.position.y - destroyPosition.y) <= gameParameters.bomb_drone_abs_limit)
            {
                poolMech.enqueue(gameObject, parentObject);
            }
        }
        else
        {
            Debug.Log("something went wrong");
        }


    }
}
