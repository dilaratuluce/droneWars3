
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //Vector3 health_plus_rotation;
    //Vector3 zeroPos = new Vector3(0,0,0);

    Slider EnemyHealthSlider;

    [SerializeField] AI_drone AI_drone; // doo


    void Start()
    {
        health = FindObjectOfType<manager>();
        AI_drone = FindObjectOfType<AI_drone>(); //doo
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
    }
    IEnumerator ReactivateHealthDrone(GameObject healthDrone)
    {
        yield return new WaitForSeconds(12f); // Wait for 12 seconds before reactivating the health drone
        healthDrone.SetActive(true);
    }
    IEnumerator ReactivateEnemyDrone(GameObject enemyDrone)
    {
        yield return new WaitForSeconds(20f); // Wait for 30 seconds before reactivating the enemy drone,
        EnemyHealthSlider = enemyDrone.GetComponentsInChildren<Slider>()[0];
        EnemyHealthSlider.value = 100;
        enemyDrone.SetActive(true);
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
            else if (hit.transform.tag.Equals("enemy"))
            {
                EnemyHealthSlider = hit.transform.gameObject.GetComponentsInChildren<Slider>()[0];
                if(EnemyHealthSlider.value > 25)
                {
                    EnemyHealthSlider.value -= 25;

                }
                else
                {
                    EnemyHealthSlider.value = 0;
                    hit.transform.gameObject.SetActive(false);
                    health.incScore(5);
                    Instantiate(explosionEffect, hit.transform.position, hit.transform.rotation);

                }
                StartCoroutine(ReactivateEnemyDrone(hit.transform.gameObject));
            }

            else if (hit.transform.tag.Equals("AI_drone")) // doo
            {
                EnemyHealthSlider = hit.transform.gameObject.GetComponentsInChildren<Slider>()[0];
                if (EnemyHealthSlider.value > 25)
                {
                    AI_drone = hit.transform.gameObject.GetComponent<AI_drone>();
                    EnemyHealthSlider.value -= 25;
                    AI_drone.changePosBool(true); 
                    //Debug.Log("changePos is true");

                }
                else
                {
                    EnemyHealthSlider.value = 0;
                    Destroy(hit.transform.gameObject);
                    health.incScore(5);
                    Instantiate(explosionEffect, hit.transform.position, hit.transform.rotation);

                }


            }

            else if (hit.transform.tag.Equals("health_drone"))
            {
                Debug.Log("health drone shooted");
                hit.transform.gameObject.SetActive(false);
                health.incHealth(30);
                health.incScore(5);
                //health_plus_rotation = new Vector3(hit.transform.rotation.x, (zeroPos - transform.position).normalized.y, hit.transform.rotation.z);
                Instantiate(health_plus, hit.transform.position, hit.transform.rotation); // health code line
                Instantiate(health_explosionEffect, hit.transform.position, hit.transform.rotation);
                StartCoroutine(ReactivateHealthDrone(hit.transform.gameObject));
            }
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


        


    


