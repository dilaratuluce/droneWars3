using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory_activator : MonoBehaviour
{

    [SerializeField] GameObject inventory;
    [SerializeField] bool isBpressed;

    // Start is called before the first frame update
    void Start()
    {
        isBpressed = false;

    }

    public bool getIsPressedB()
    {
        return isBpressed;
    }

    public void setIsPressedB(bool boole)
    {
        isBpressed = boole;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (inventory.activeInHierarchy)
            {
                isBpressed = false;
                inventory.SetActive(false);
            }
            else
            {
                isBpressed = true;
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
