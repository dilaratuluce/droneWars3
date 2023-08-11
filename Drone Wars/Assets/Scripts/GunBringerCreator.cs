using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBringerCreator : MonoBehaviour
{
    [SerializeField] GameObject gunBringer1;
    [SerializeField] GameObject gunBringer2;

    [SerializeField] float firstCreateTime1;
    [SerializeField] float firstCreateTime2;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("ActivateGunBringer1", firstCreateTime1);
        Invoke("ActivateGunBringer2", firstCreateTime2);
    }
    void ActivateGunBringer1()
    {
        gunBringer1.SetActive(true);
    }
    void ActivateGunBringer2()
    {
        gunBringer2.SetActive(true);
    }

}
