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
    [SerializeField] private GameObject bomb_explosionEffect;
    //[SerializeField] private ParticleSystem muzzle_flash;
    [SerializeField] private Transform BulletSpawnPoint;
    [SerializeField] private ParticleSystem ImpactParticleSystem;
    //Vector3 rot;
    [SerializeField] private GameObject health_plus; // health code line
    Slider EnemyHealthSlider;
    [SerializeField] AI_drone AI_drone; // doo
    [SerializeField] float bombRadius;
    [SerializeField] Collider[] bombColliders;
    int bombedObjectNum = 0;
    Combo combo;

    void Start()
    {
        health = FindObjectOfType<manager>();
        AI_drone = FindObjectOfType<AI_drone>(); //doo
        combo = FindObjectOfType<Combo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
           //muzzle_flash.Play();

        }
       /* rot = fpsCam.transform.localRotation.eulerAngles;
        if (rot.x != 0 || rot.y != 0 )
        {
            fpsCam.transform.localRotation = Quaternion.Slerp(fpsCam.transform.localRotation,Quaternion.Euler(0,0,0),Time.deltaTime*3);
        }*/
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
    /*void recoil()
    {
        float recX = Random.Range(minX,maxX);
        float recY = Random.Range(minY,maxY);
        fpsCam.transform.localRotation = Quaternion.Euler(rot.x - recY, rot.y + recX, rot.z);

    }*/

    void Shoot()
    {

        // Storing info about what we hit with our ray
        RaycastHit hit;
       // recoil();
        // shoot out our ray and checking if we hit something
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            if (hit.transform.tag.Equals("drone"))
            {
                Destroy(hit.transform.gameObject);
                Instantiate(explosionEffect, hit.transform.position, hit.transform.rotation);
                health.incCombo();
                if (health.getCombo() > 5) health.incScore(10);
                else if (health.getCombo() == 5)
                {
                    combo.Open();
                    health.incScore(10);
                }
                else health.incScore(5);
            }
            else if (hit.transform.tag.Equals("enemy"))
            {
                EnemyHealthSlider = hit.transform.gameObject.GetComponentsInChildren<Slider>()[0];
                if (EnemyHealthSlider.value > 25)
                {
                    EnemyHealthSlider.value -= 25;

                }
                else
                {
                    EnemyHealthSlider.value = 0;
                    hit.transform.gameObject.SetActive(false);
                    Instantiate(explosionEffect, hit.transform.position, hit.transform.rotation);
                    health.incCombo();
                    if (health.getCombo() > 5) health.incScore(10);
                    else if (health.getCombo() == 5)
                    {
                        combo.Open();
                        health.incScore(10);
                    }
                    else health.incScore(5);

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

                }
                else
                {
                    EnemyHealthSlider.value = 0;
                    Destroy(hit.transform.gameObject);
                    Instantiate(explosionEffect, hit.transform.position, hit.transform.rotation);
                    health.incCombo();
                    if (health.getCombo() > 5) health.incScore(10);
                    else if (health.getCombo() == 5)
                    {
                        combo.Open();
                        health.incScore(10);
                    }
                    else health.incScore(5);

                }


            }

            else if (hit.transform.tag.Equals("health_drone"))
            {
                Debug.Log("health drone shooted");
                hit.transform.gameObject.SetActive(false);
                health.incHealth(30);
                Instantiate(health_plus, hit.transform.position, hit.transform.rotation); // health code line
                Instantiate(health_explosionEffect, hit.transform.position, hit.transform.rotation);
                StartCoroutine(ReactivateHealthDrone(hit.transform.gameObject));
                health.incCombo();
                if (health.getCombo() > 5) health.incScore(10);
                else if (health.getCombo() == 5)
                {
                    combo.Open();
                    health.incScore(10);
                }
                else health.incScore(5);
            }
            else if (hit.transform.tag.Equals("bomb_drone"))
            {
                bombColliders = Physics.OverlapSphere(hit.transform.position, bombRadius);
                bombedObjectNum = 0;
                foreach (Collider collider in bombColliders)
                {
                    if (collider.gameObject.tag.Equals("health_drone"))
                    {
                        health.incHealth(30);
                    }
                    Destroy(collider.gameObject);
                    bombedObjectNum++;
                }
                Instantiate(bomb_explosionEffect, hit.transform.position, hit.transform.rotation);
                health.incCombo();
                if (health.getCombo() > 5) health.incScore(10*bombedObjectNum);
                else if (health.getCombo() == 5)
                {
                    combo.Open();
                    health.incScore(10 * bombedObjectNum);
                }
                else health.incScore(5 * bombedObjectNum);
            }
            else health.setCombo();
        }
        else health.setCombo();

    }
                   
}


        


    


