using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rareDrone : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    float desiredDuration = 1f;
    float elapsedTime;

    bool comingToRight;

    bool round1, round2, round3, round4, round5;
    Vector3 destroyPosition;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(Random.Range(35, 50), Random.Range(13, 25), Random.Range(25, 45));

        elapsedTime = 0;
        comingToRight = true;
        round1 = true;
        round2 = round3 = round4 = round5 = false;

    }

    void Update()
    {
        if (comingToRight && (round1 || round3))
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

            if (Mathf.Abs(transform.position.y - endPosition.y) <= 0.1) // localPosition??
            {
                //Destroy(this.gameObject);
                comingToRight = false;
                startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                endPosition = new Vector3(Random.Range(-35, -50), Random.Range(13, 25), Random.Range(25, 45));
                elapsedTime = 0;
                if (round1)
                {
                    Debug.Log("round1 bitti");
                    round1 = false;
                    round2 = true;
                }
                else
                {
                    Debug.Log("round3 bitti");
                    round3 = false;
                    round4 = true;
                }
            }
        }
        else if(!comingToRight && (round2 || round4))
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);
            if (Mathf.Abs(transform.position.y - endPosition.y) <= 0.1)
            {
                comingToRight = true;
                startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                endPosition = new Vector3(Random.Range(35, 50), Random.Range(13, 25), Random.Range(25, 45));
                elapsedTime = 0;
                if (round2)
                {
                    Debug.Log("round2 bitti");
                    round2 = false;
                    round3 = true;
                }
                else
                {
                    Debug.Log("round4 bitti");
                    round4 = false;
                    round5 = true;
                }
            }
        }
        else if(comingToRight && round5)// comingToRight is true and round5 (last round)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            destroyPosition = new Vector3(140, 10, 25);
            transform.position = Vector3.Lerp(startPosition, destroyPosition, percentageComplete);
            if (Mathf.Abs(transform.position.y - destroyPosition.y) <= 0.1)
            {
                Debug.Log("round5 bitti");
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("terslik oldu");
        }


    }
}
