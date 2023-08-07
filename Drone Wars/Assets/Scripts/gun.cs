using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class gun : MonoBehaviour
{
    [SerializeField] LayerMask aimColliderMask = new LayerMask();
    [SerializeField] private ParticleSystem muzzle_flash;
    [SerializeField] Transform bullet_prefab;
    [SerializeField] private Transform BulletSpawnPoint;

    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 aimDir = (mouseWorldPosition - BulletSpawnPoint.position).normalized;
            Instantiate(bullet_prefab,BulletSpawnPoint.position, Quaternion.LookRotation(aimDir,Vector3.up));
            muzzle_flash.Play();

        }


    }
 

                   
}


        


    


