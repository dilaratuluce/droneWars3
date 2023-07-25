using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class standingDroneActivator : MonoBehaviour
{
    [SerializeField] GameObject gameObject1;
    [SerializeField] float activateTime1;
    [SerializeField] GameObject gameObject2;
    [SerializeField] float activateTime2;


    void Start()
    {
        gameObject1.SetActive(false);
        gameObject2.SetActive(false);
        StartCoroutine("SetActive"); // 
    }

    IEnumerator SetActive() // gameobject2 will be activated in activeTime2 AFTER gameObject1 is activated
    {
        yield return new WaitForSeconds(activateTime1); // when this ends
        gameObject1.SetActive(true);

        yield return new WaitForSeconds(activateTime2); // it will continue with this
        gameObject2.SetActive(true);
    }
    void Update()
    {

    }
}
