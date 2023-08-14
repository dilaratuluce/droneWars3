using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInAim : MonoBehaviour
{
    [SerializeField] private int zoom = 20;
    [SerializeField] private int normal = 60;
    [SerializeField] private float smooth = 5;

    private bool isZoomed = false;
    private bool notZoomed = true;

    WeaponSwitch weaponSwitch;
    private void Awake()
    {
        weaponSwitch = FindObjectOfType<WeaponSwitch>();
    }

    void Update()
    {
        if(weaponSwitch.getSelectedWeapon() != 1)
        {
            if (Input.GetMouseButtonDown(1))
            {
                isZoomed = !isZoomed;
            }

            if (isZoomed)
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, zoom, Time.deltaTime * smooth);
            }

            if (Input.GetMouseButtonUp(1))
            {
                isZoomed = !notZoomed;
            }

            if (notZoomed)
            {
                GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, normal, Time.deltaTime * smooth);
            }

        }

            

        

    }
    /*The isZoomed and notZoomed variables are used to toggle between zoomed and normal states. 
      When the right mouse button is pressed down, the camera switches to zoomed mode (isZoomed becomes true),
      and when the right mouse button is released, it goes back to the normal mode (notZoomed becomes true). 
      The smooth variable controls how fast the zoom transitions happen, as it affects the speed of the interpolation.*/
}
