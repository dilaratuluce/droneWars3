
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

public class GrenadeLauncher : MonoBehaviour
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
    GrenadeLauncherAnimation grenadeLauncherAnimation;
    [Header("****Trajectory Display****")]
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] int linePoints = 175;
    [SerializeField] float timeIntervalInPoints = 0.01f;
    bulletProjectile projectile;

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
        projectile = FindObjectOfType<bulletProjectile>();
        poolMech = FindObjectOfType<poolMechanism>();
        grenadeLauncherAnimation = FindObjectOfType<GrenadeLauncherAnimation>();
    }
    private void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {


        ammoText.text = currentAmmo + "/" + maxAmmo;
        if (lineRenderer != null)
        {
            if (Input.GetMouseButton(1))
            {
                DrawTrajectory();
                lineRenderer.enabled = true;
            }
            else
                lineRenderer.enabled = false;
        }
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
        grenadeLauncherAnimation.Open();
        isReloading = true;
        Debug.Log("Reloading");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        grenadeLauncherAnimation.Close();
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
    void DrawTrajectory()
    {

        /*Vector3 aimDir = (mouseWorldPosition.position - BulletSpawnPoint.position).normalized;
        rotation = Quaternion.LookRotation(aimDir, Vector3.up);*/

        Vector3 origin = BulletSpawnPoint.position;
        Vector3 startVelocity = BulletSpawnPoint.forward * gameParameters.grenadeLauncherSpeed; // Adjust bullet speed as needed

        float timeStep = timeIntervalInPoints;

        lineRenderer.positionCount = linePoints;

        for (int i = 0; i < linePoints; i++)
        {
            float time = i * timeStep;
            float x = startVelocity.x * time;
            float y = startVelocity.y * time - 0.5f * Mathf.Abs(Physics.gravity.y) * time * time;
            float z = startVelocity.z * time; // Add this line to calculate Z-coordinate

            Vector3 point = new Vector3(x, y, z);
            lineRenderer.SetPosition(i, origin + point);
        }
    }

}













