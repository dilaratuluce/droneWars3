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

    //bulletProjectile bulletScript;
    ShootedDronePosition shootedPosition;

    poolMechanism poolMech;

    [SerializeField] GameObject healthPlusParent;

    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();
        //bulletScript = FindObjectOfType<bulletProjectile>();
        shootedPosition = FindObjectOfType<ShootedDronePosition>();

        transform.position = shootedPosition.getDronePos();

        startPosition = transform.position;
        endPosition = new Vector3(transform.position.x, transform.position.y + gameParameters.healthPlus_rising_number, transform.position.z);

        comingToPlayer = false;

        elapsedTime = 0;


    }

    void Update()
    {
        if (!comingToPlayer)
        {
            elapsedTime += Time.deltaTime;
            float percentageComplete = elapsedTime / desiredDuration;

            transform.position = Vector3.Lerp(startPosition, endPosition, percentageComplete);

            if (transform.localPosition.y >= startPosition.y + gameParameters.healthPlus_rising_number - gameParameters.healthPlus_error_number) // drone is close enough to startPosition.y+3
            {
                comingToPlayer = true;
                comingStartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                comingEndPosition = manager.Instance.getPosition();
                comingElapsedTime = 0;

            }
        }
        else
        {
            comingElapsedTime += Time.deltaTime;
            float comingPercentageComplete = comingElapsedTime / comingDesiredDuration;

            transform.position = Vector3.Lerp(comingStartPosition, comingEndPosition, comingPercentageComplete);
            if (Vector3.Distance(transform.position, comingEndPosition) <= gameParameters.healthPlus_error_number)
            {
                poolMech.enqueue(gameObject, healthPlusParent);
                //Destroy(this.gameObject);//!!!!
                
            }
        }
        

    }
}
