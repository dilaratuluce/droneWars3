using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthPlus : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    float desiredDuration = 2f;
    float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, transform.position.y + 3, transform.position.z);

    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float percentageComplete = elapsedTime / desiredDuration;

        transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

        if (transform.localPosition.y >= startPosition.y+3 - 0.1)
        {
            Destroy(this.gameObject);
        }

    }
}
