using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    TakingGun takingGun;
    WeaponSwitch weaponSwitch;
    //bool isBpressed;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        gameObject.SetActive(false);
        takingGun = FindObjectOfType<TakingGun>();
        weaponSwitch = FindObjectOfType<WeaponSwitch>();

        
    }

    void Update()
    {

        if (takingGun.getGun1Shooted())
        {
            transform.GetChild(1).gameObject.SetActive(true);
        }
        if (takingGun.getGun2Shooted())
        {
            transform.GetChild(2).gameObject.SetActive(true);
        }
        


        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }*/
    }
}
