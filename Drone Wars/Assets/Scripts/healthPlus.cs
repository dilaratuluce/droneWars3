using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPlus : MonoBehaviour
{
    //healthPlus have to lerp movements, first lerp is a 3 unit upwards move, second one is towards the player 

    Vector3 startPosition; // first lerp variabbles
    Vector3 endPosition;
    float desiredDuration = 1f;
    float elapsedTime;

    bool comingToPlayer; // second lerp variables
    Vector3 comingStartPosition;
    Vector3 comingEndPosition;
    float comingDesiredDuration = 0.5f;
    float comingElapsedTime;
    referancePoint comingPosition;

    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

        comingToPlayer = false;

    }

    void Update()
    {
        if (!comingToPlayer)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

            if (transform.localPosition.y >= startPosition.y + 3 - 0.1) // drone is close enough to startPosition.y+3
            {
                comingToPlayer = true;
                comingStartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                comingEndPosition = new Vector3();
                comingElapsedTime = 0;
                comingPosition = FindObjectOfType<referancePoint>(); // singleton game manager'dan alsın player konumunu
            }
        }
        else
        {
            comingElapsedTime += Time.deltaTime;
            float comingPercentageComplete = comingElapsedTime / comingDesiredDuration;

            transform.position = Vector3.Lerp(comingStartPosition, comingEndPosition, comingPercentageComplete);
            if (transform.localPosition.y >= endPosition.y - 0.1)
            {
                Destroy(this.gameObject);
            }
        }
        

    }
}
