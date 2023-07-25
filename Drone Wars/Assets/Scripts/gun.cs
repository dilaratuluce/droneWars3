
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{

    [SerializeField] private float range = 100f;
    [SerializeField] private Camera fpsCam;
    manager health;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject health_explosionEffect;
    //[SerializeField] private ParticleSystem muzzle_flash;
   // [SerializeField]
   // private Vector3 BulletSpreadVariance = new Vector3(0.1f, 0.1f, 0.1f);
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField]
    private ParticleSystem ImpactParticleSystem;
    //[SerializeField] TrailRenderer BulletTrail;
    //private float ShootDelay = 0.1f;
    //private float LastShootTime;

    [SerializeField] private GameObject health_plus; // health code line


    void Start()
    {
        health = FindObjectOfType<manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {

        // Storing info about what we hit with our ray
        //TrailRenderer trail = Instantiate(BulletTrail, BulletSpawnPoint.position, Quaternion.identity);
        RaycastHit hit;
        //muzzle_flash.Play();
        // shoot out our ray and checking if we hit something
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
                
            //StartCoroutine(SpawnTrail(trail,hit));
            //LastShootTime = Time.time;

            if (hit.transform.tag.Equals("drone"))
            {              
                Destroy(hit.transform.gameObject);
                health.incScore(5);
                Instantiate(explosionEffect, hit.transform.position, hit.transform.rotation);
            }

            else if (hit.transform.tag.Equals("health_drone"))
            {
                Debug.Log("health drone shooted");
                Destroy(hit.transform.gameObject);
                health.incHealth(30);
                health.incScore(5);
                Instantiate(health_plus, hit.transform.position, hit.transform.rotation); // health code line
                Instantiate(health_explosionEffect, hit.transform.position, hit.transform.rotation);
            }

        }
        /*else
        {
            //Debug.Log("nom nom");
            trail.transform.position = BulletSpawnPoint.forward;
        }*/
        
            
    }/*
    private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit hit)
    {
        float time = 0;
        
        while(time < 1)
        {
            trail.transform.position = Vector3.Lerp(BulletSpawnPoint.position,hit.point,time);
            time += Time.deltaTime / trail.time;
            yield return null;
        }
        trail.transform.position = hit.point;
        Instantiate(ImpactParticleSystem, hit.point, Quaternion.LookRotation(hit.normal));

    }*/

}
        


    


