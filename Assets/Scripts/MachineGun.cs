using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class MachineGun : MonoBehaviour
{
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private Transform mouseWorldPosition;
    [SerializeField] int damage;
    int currentAmmo;
    private bool isReloading = false;
    [SerializeField] int maxAmmo;
    poolMechanism poolMech;
    [SerializeField] float reloadTime;
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] ParticleSystem muzzleFlash;
    Quaternion rotation;
    MachineGunAnimation machineGunAnimation;

    [SerializeField] float fireRate = 10f; // Shots per second
    private float nextFireTime = 0f; // To track the next allowed firing time

    public void setCurrentAmmoToMax()
    {
        currentAmmo = maxAmmo;
    }
    private void Start()
    {
        muzzleFlash.Pause();
        currentAmmo = maxAmmo;
        poolMech = FindObjectOfType<poolMechanism>();
        machineGunAnimation = FindObjectOfType<MachineGunAnimation>();
    }

    private void OnEnable()
    {
        isReloading = false;
    }

    void Update()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;

        if (isReloading) return;

        if (currentAmmo <= maxAmmo && Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine("Reload");
        }

        if (currentAmmo > 0 && Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            muzzleFlash.Play();
            Fire();
            nextFireTime = Time.time + 1f / fireRate; // Update the next allowed firing time
        }
    }

    void Fire()
    {
        currentAmmo--;

        Vector3 aimDir = (mouseWorldPosition.position - BulletSpawnPoint.position).normalized;
        rotation = Quaternion.LookRotation(aimDir, Vector3.up);
        poolMech.dequeue(gameObject);
    }

    IEnumerator Reload()
    {
        machineGunAnimation.Open();
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        machineGunAnimation.Close();
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
    public float getReloadTime()
    {
        return reloadTime;
    }
}