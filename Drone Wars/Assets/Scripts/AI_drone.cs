using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI_drone : MonoBehaviour
{
    //[SerializeField]
    bool changePosition = false;

    Vector3 startPosition;
    Vector3 endPosition;
    float desiredDuration = 1.5f;
    float elapsedTime = 0;

    bool startEndDetermined = false;

    Slider EnemyHealthSlider;


    void OnEnable()
    {
        startPosition = new Vector3(Random.Range(5, 40), Random.Range(13, 25), Random.Range(25, 45));
        gameObject.transform.position = startPosition;

        EnemyHealthSlider = gameObject.GetComponentsInChildren<Slider>()[0];
        EnemyHealthSlider.value = 100;

    }

    public void changePosBool(bool boole)
    {
        changePosition = boole;
    }

    void startEndUpdater()
    {

        startPosition = transform.position;
        if (transform.position.x < 0) // if drone is on the left, it should go to right, else it should go to left
        {
            endPosition = new Vector3(Random.Range(5, 40), Random.Range(13, 25), Random.Range(25, 45));
        }
        else
        {
            endPosition = new Vector3(Random.Range(-40, -5), Random.Range(13, 25), Random.Range(25, 45));
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

            if (Mathf.Abs(transform.position.x - endPosition.x) <= 0.1) // stop the process when drone is close enought to end point
            {
                elapsedTime = 0;
                startEndDetermined = false;
            }
        }
    }

}