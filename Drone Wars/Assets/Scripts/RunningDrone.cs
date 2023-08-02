using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningDrone : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    float desiredDuration = 10f;
    float elapsedTime;

    [SerializeField] private AnimationCurve curve; // you can change the animation curve in Unity


    void Start()
    {
        startPosition = new Vector3(-100, Random.Range(10, 25), Random.Range(20, 50));
        transform.position = startPosition;
        endPosition = new Vector3(120, transform.position.y, transform.position.z);
    }


    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startPosition, endPosition, curve.Evaluate(percentageComplete));

        if(transform.localPosition.x >= 140) 
        {
            Destroy(this.gameObject);
        }

    }
}
