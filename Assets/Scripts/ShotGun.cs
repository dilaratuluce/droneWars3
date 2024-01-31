using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class ShotGun : MonoBehaviour
{
    //[SerializeField] Transform bullet;
    [SerializeField] Transform BulletSpawnPoint;

   // [SerializeField] Transform [] mouseWorldPositions;

    [SerializeField] int damage;
    int currentAmmo;
    private bool isReloading = false;
    [SerializeField] int maxAmmo;
    poolMechanism poolMech;
    [SerializeField] float reloadTime;
    [SerializeField] private TMP_Text ammoText;

    Quaternion rotation;

    //weaponAnimation weapon_animation;
    weaponAnimation2 weapon_animation;
    int randomMousePoint;

    public void setCurrentAmmoToMax()
    {
        currentAmmo = maxAmmo;
    }
    public float getReloadTime()
    {
        return reloadTime;
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
        poolMech = FindObjectOfType<poolMechanism>();
        weapon_animation = FindObjectOfType<weaponAnimation2>();
    }
    private void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
        if (isReloading) return;
        if (currentAmmo <= maxAmmo)
        {
            Debug.Log("Press R button");
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine("Reload");

            }

        }
        if (currentAmmo > 0 && Input.GetMouseButtonDown(0))
        {
            currentAmmo--;
            Debug.Log(currentAmmo);


           /* Vector3 aimDir = (mouseWorldPositions[randomMousePoint].position - BulletSpawnPoint.position).normalized;
            rotation = Quaternion.LookRotation(aimDir, Vector3.up);*/

            //Instantiate(bullet_prefab,BulletSpawnPoint.position, Quaternion.LookRotation(aimDir,Vector3.up));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));


            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));
            //poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y, BulletSpawnPoint.position.z));

            /*poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y + 1, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x, BulletSpawnPoint.position.y - 1, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x + 1, BulletSpawnPoint.position.y + 0.5f, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x + 1, BulletSpawnPoint.position.y - 0.5f, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x - 1, BulletSpawnPoint.position.y + 0.5f, BulletSpawnPoint.position.z));
            poolMech.dequeue2(gameObject, new Vector3(BulletSpawnPoint.position.x - 1, BulletSpawnPoint.position.y - 0.5f, BulletSpawnPoint.position.z));*/

        }

    }
    IEnumerator Reload()
    {
        weapon_animation.Open();
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        weapon_animation.Close();
        isReloading = false;
    }

    public int getDamage()
    {
        return damage;

    }

}








