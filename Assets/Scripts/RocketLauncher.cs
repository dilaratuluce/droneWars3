using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class RocketLauncher : MonoBehaviour
{
    //[SerializeField] Transform bullet;
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private Transform mouseWorldPosition;
    [SerializeField] int damage;
    int currentAmmo;
    private bool isReloading = false;
    [SerializeField] int maxAmmo;
    poolMechanism poolMech;
    [SerializeField] float reloadTime;
    [SerializeField] private TMP_Text ammoText;

    Quaternion rotation;
    weaponAnimation weapon_animation;

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
        weapon_animation = FindObjectOfType<weaponAnimation>();
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
            Vector3 aimDir = (mouseWorldPosition.position - BulletSpawnPoint.position).normalized;
            rotation = Quaternion.LookRotation(aimDir, Vector3.up);
            //Instantiate(bullet_prefab,BulletSpawnPoint.position, Quaternion.LookRotation(aimDir,Vector3.up));
            poolMech.dequeue(gameObject);

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
    public Quaternion getRotation()
    {
        return rotation;
    }
    public int getDamage()
    {
        return damage;

    }

}








