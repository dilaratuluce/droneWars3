using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poolMechanism : MonoBehaviour
{
    //this script will be attached to the poolParent object
    // in the shooot function, first call dequeue, then use the bullet however you want/throw it, then call enqueue

    //[SerializeField] GameObject poolParent; // scripti bağladığın objenin kendisini koy buraya

    //GameObject firstPasiveGameObject;

    //  RunningDrone running_drone;

    void Start()
    {
        // running_drone = FindObjectOfType<RunningDrone>();
    }

    // use this when you want to activate/instantiate a game object
    public void dequeue(GameObject parentObject)
    {
        GameObject firstPasiveGameObject = null;
        //firstPasiveGameObject = gameObject.transform.GetChild(0).gameObject;                
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            if (parentObject.transform.GetChild(i).gameObject.activeSelf == false && !parentObject.transform.GetChild(i).tag.Equals("not_a_pool_object") && !parentObject.transform.GetChild(i).tag.Equals("rotating_enemy"))
            {
                firstPasiveGameObject = parentObject.transform.GetChild(i).gameObject;
                break;
            }
        }

        if (firstPasiveGameObject) // there is at least one pasive game Object
        {
            firstPasiveGameObject.transform.parent = null;
            firstPasiveGameObject.SetActive(true);
        }

        // else if there is not one active game object, it does nothing

    }
    public void dequeue2(GameObject parentObject, Vector3 position)
    {
        GameObject firstPasiveGameObject = null;
        //firstPasiveGameObject = gameObject.transform.GetChild(0).gameObject;                
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            if (parentObject.transform.GetChild(i).gameObject.activeSelf == false && !parentObject.transform.GetChild(i).tag.Equals("not_a_pool_object") && !parentObject.transform.GetChild(i).tag.Equals("rotating_enemy"))
            {
                firstPasiveGameObject = parentObject.transform.GetChild(i).gameObject;
                break;
            }
        }

        if (firstPasiveGameObject) // there is at least one pasive game Object
        {
            firstPasiveGameObject.transform.parent = null;
            firstPasiveGameObject.transform.position = position;
            firstPasiveGameObject.SetActive(true);
        }
        // else if there is not one active game object, it does nothing

    }

    public void dequeue3(GameObject parentObject, int yRotation)
    {
        GameObject firstPasiveGameObject = null;
        //firstPasiveGameObject = gameObject.transform.GetChild(0).gameObject;                
        for (int i = 0; i < parentObject.transform.childCount; i++)
        {
            if (parentObject.transform.GetChild(i).gameObject.activeSelf == false && !parentObject.transform.GetChild(i).tag.Equals("not_a_pool_object") && !parentObject.transform.GetChild(i).tag.Equals("rotating_enemy"))
            {
                firstPasiveGameObject = parentObject.transform.GetChild(i).gameObject;
                break;
            }
        }

        if (firstPasiveGameObject) // there is at least one pasive game Object
        {
            firstPasiveGameObject.transform.parent = null;
            firstPasiveGameObject.SetActive(true);
            Vector3 v = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(v.x, v.y + yRotation, v.z);
            
        }
        // else if there is not one active game object, it does nothing

    }

    // use this when you shoot a game object or you want it to be pasive
    public void enqueue(GameObject childObject, GameObject parentObject)
    {
        Debug.Log("enqueue");
        childObject.transform.position = new Vector3(-100, 15, 35); //
        childObject.transform.parent = parentObject.transform;
        childObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}