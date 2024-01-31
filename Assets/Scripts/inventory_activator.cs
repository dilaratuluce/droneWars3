using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_activator : MonoBehaviour
{

    [SerializeField] GameObject inventory;


    // Start is called before the first frame update




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (inventory.activeInHierarchy)
            {
                inventory.SetActive(false);
            }
            else
            {
                inventory.SetActive(true);
            }
        }


        /*if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (inventory.activeInHierarchy)
            {
                isBpressed = true;
                inventory.SetActive(false);
            }
        }*/
    }
}
