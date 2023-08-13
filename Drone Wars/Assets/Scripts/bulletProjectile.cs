﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
public class bulletProjectile : MonoBehaviour
{
    Rigidbody bulletRigidbody;
    [SerializeField] float bullet_speed;
    [SerializeField] private ParticleSystem ImpactParticleSystem;
    Slider EnemyHealthSlider;
    AI_drone AI_drone; // doo // başında [SerField] vardı sildin
    [SerializeField] float bombRadius;
    [SerializeField] Collider[] bombColliders;
    int bombedObjectNum = 0;
    Combo combo;

    poolMechanism poolMech;
    // poolMechanism2 poolMech2;
    [SerializeField] GameObject runningDroneParent;
    [SerializeField] GameObject rotatingDroneParent;
    [SerializeField] GameObject rotatingEnemyDroneParent;
    [SerializeField] GameObject AIDroneParent;
    [SerializeField] GameObject runningHealthDroneParent;
    [SerializeField] GameObject bombDroneParent;
    [SerializeField] GameObject standingEnemyDroneParent;
    [SerializeField] GameObject standingHealthDroneParent;
    [SerializeField] GameObject healthPlusCreator;
    [SerializeField] GameObject explosionCreator;
    [SerializeField] GameObject healthExplosionCreator;
    [SerializeField] GameObject bombExplosionCreator;
    [SerializeField] float spread_value = 0;

    [SerializeField] Transform BulletSpawnPoint;

    public GameObject bulletParent; // (gun)


    //Vector3 shootedDronePosition;

    ShootedDronePosition shootedPosition;

    /*public Vector3 getPosition()
    {
        return shootedDronePosition;
    }*/

    gun my_gun;
    TakingGun takingGun;


    void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        shootedPosition = FindObjectOfType<ShootedDronePosition>();

        AI_drone = FindObjectOfType<AI_drone>(); //doo
        combo = FindObjectOfType<Combo>();
        poolMech = FindObjectOfType<poolMechanism>();
        my_gun = FindObjectOfType<gun>();
        takingGun = FindObjectOfType<TakingGun>();

        /*Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
        }

        Vector3 aimDir = (mouseWorldPosition - BulletSpawnPoint.position).normalized; */
        gameObject.transform.position = BulletSpawnPoint.position;
        gameObject.transform.rotation = my_gun.getRotation();
        Quaternion spreadRotation = Quaternion.Euler(spread_value, 0, 0);
        gameObject.transform.rotation *= spreadRotation;
        bulletRigidbody.velocity = transform.forward * bullet_speed;


    }
    void OnCollisionEnter(Collision collision)
    {
        //Destroy(gameObject);
        //shootedDronePosition = collision.transform.position;
        shootedPosition.setDronePos(collision.transform.position);
        if (collision.transform.tag.Equals(TagHolder.running_drone))
        {
            //Destroy(collision.transform.gameObject); // destroy ve intantiate kullanmıyoruz, queue kullan; enqueue, dequeue

            //Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
            //shootedDronePosition = collision.transform.position;
            poolMech.dequeue2(explosionCreator, collision.transform.position);
            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point);
            }
            else manager.Instance.incScore(gameParameters.score_point);
            poolMech.enqueue(collision.transform.gameObject, runningDroneParent); // new line
        }
        else if (collision.transform.tag.Equals(TagHolder.rotating_drone))
        {
            poolMech.dequeue2(explosionCreator, collision.transform.position);
            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point);
            }
            else manager.Instance.incScore(gameParameters.score_point);
            poolMech.enqueue(collision.transform.parent.gameObject, rotatingDroneParent); // new line, parent is the one who needs to be moved here
        }

        else if (collision.transform.tag.Equals(TagHolder.gun_bringer1))
        {
            poolMech.dequeue2(explosionCreator, collision.transform.position);
            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point);
            }
            else manager.Instance.incScore(gameParameters.score_point);
            //poolMech.enqueue(collision.transform.parent.gameObject, rotatingDroneParent); // new line, parent is the one who needs to be moved here
            collision.transform.gameObject.SetActive(false);
            takingGun.setGun1ShootedTrue();
        }
        else if (collision.transform.tag.Equals(TagHolder.gun_bringer2))
        {
            poolMech.dequeue2(explosionCreator, collision.transform.position);
            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point);
            }
            else manager.Instance.incScore(gameParameters.score_point);
            //poolMech.enqueue(collision.transform.parent.gameObject, rotatingDroneParent); // new line, parent is the one who needs to be moved here
            collision.transform.gameObject.SetActive(false);
            takingGun.setGun2ShootedTrue();


        }

        else if (collision.transform.tag.Equals(TagHolder.rotating_enemy))
        {
            EnemyHealthSlider = collision.transform.gameObject.GetComponentsInChildren<Slider>()[0];
            if (EnemyHealthSlider.value > my_gun.getDamage())
            {
                EnemyHealthSlider.value -= my_gun.getDamage();

            }
            else
            {
                EnemyHealthSlider.value = 0;
                //Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
                //shootedDronePosition = collision.transform.position;
                poolMech.dequeue2(explosionCreator, collision.transform.position);
                manager.Instance.incCombo();
                if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
                else if (manager.Instance.getCombo() == gameParameters.combo_limit)
                {
                    combo.Open();
                    manager.Instance.incScore(gameParameters.buffed_score_point);
                }
                else manager.Instance.incScore(gameParameters.score_point);

                poolMech.enqueue(collision.transform.parent.gameObject, rotatingEnemyDroneParent); // new line, parent is the one who needs to be moved here
            }
            //StartCoroutine(ReactivateEnemyDrone(collision.transform.gameObject));
        }

        else if (collision.transform.tag.Equals("enemy"))
        {
            EnemyHealthSlider = collision.transform.gameObject.GetComponentsInChildren<Slider>()[0];
            if (EnemyHealthSlider.value > my_gun.getDamage())
            {
                EnemyHealthSlider.value -= my_gun.getDamage();

            }
            else
            {
                EnemyHealthSlider.value = 0;
                //collision.transform.gameObject.SetActive(false);
                //Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
                //shootedDronePosition = collision.transform.position;
                poolMech.dequeue2(explosionCreator, collision.transform.position);
                manager.Instance.incCombo();
                if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
                else if (manager.Instance.getCombo() == gameParameters.combo_limit)
                {
                    combo.Open();
                    manager.Instance.incScore(gameParameters.buffed_score_point);
                }
                else manager.Instance.incScore(gameParameters.score_point);

                poolMech.enqueue(collision.transform.gameObject, standingEnemyDroneParent); // new line // new line, parent is the one who needs to be moved here
            }
            //StartCoroutine(ReactivateEnemyDrone(collision.transform.gameObject));
        }



        else if (collision.transform.tag.Equals(TagHolder.AI_drone)) // doo
        {
            EnemyHealthSlider = collision.transform.gameObject.GetComponentsInChildren<Slider>()[0];
            if (EnemyHealthSlider.value > my_gun.getDamage()) // gameParameter.cs'e koy parametreleri, public sontant olarak koy, cs dosyaları büyük harfle başlasın
            {
                AI_drone = collision.transform.gameObject.GetComponent<AI_drone>();
                EnemyHealthSlider.value -= my_gun.getDamage();
                AI_drone.changePosBool(true);

            }
            else
            {
                EnemyHealthSlider.value = 0;
                //Destroy(collision.transform.gameObject);

                //Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
                //shootedDronePosition = collision.transform.position;
                poolMech.dequeue2(explosionCreator, collision.transform.position);
                manager.Instance.incCombo();
                if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
                else if (manager.Instance.getCombo() == gameParameters.combo_limit)
                {
                    combo.Open();
                    manager.Instance.incScore(gameParameters.buffed_score_point);
                }
                else manager.Instance.incScore(gameParameters.score_point);

                poolMech.enqueue(collision.transform.gameObject, AIDroneParent); // new line

            }


        }

        else if (collision.transform.tag.Equals("health_drone"))
        {

            //Debug.Log("health drone shooted");
            manager.Instance.incHealth(30);

            //Instantiate(health_plus, collision.transform.position, collision.transform.rotation); // health code line
            //shootedDronePosition = collision.transform.position;
            poolMech.dequeue(healthPlusCreator);
            poolMech.dequeue2(healthExplosionCreator, collision.transform.position); //bunu yap sonra

            //Instantiate(health_explosionEffect, collision.transform.position, collision.transform.rotation);



            manager.Instance.incHealth(gameParameters.health_point);
            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point);
            }
            else manager.Instance.incScore(gameParameters.score_point);
            poolMech.enqueue(collision.transform.gameObject, standingHealthDroneParent); // new line
        }

        else if (collision.transform.tag.Equals(TagHolder.running_health_drone))
        {
            //Debug.Log("running health drone shooted");

            //Instantiate(health_plus, collision.transform.position, collision.transform.rotation); // health code line
            //shootedDronePosition = collision.transform.position;
            poolMech.dequeue(healthPlusCreator);
            poolMech.dequeue2(healthExplosionCreator, collision.transform.position);

            //Instantiate(health_explosionEffect, collision.transform.position, collision.transform.rotation);
            //poolMech.dequeue2(explosionCreator,shootedDronePosition); bunu yap sonra

            manager.Instance.incHealth(gameParameters.health_point);
            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point);
            }
            else manager.Instance.incScore(gameParameters.score_point);

            poolMech.enqueue(collision.transform.gameObject, runningHealthDroneParent); // new line

        }

        else if (collision.transform.tag.Equals(TagHolder.bomb_drone))
        {
            bombColliders = Physics.OverlapSphere(collision.transform.position, bombRadius);
            bombedObjectNum = 0;
            //Instantiate(bomb_explosionEffect, collision.transform.position, collision.transform.rotation);
            //shootedDronePosition = collision.transform.position;
            poolMech.dequeue2(bombExplosionCreator, collision.transform.position);
            foreach (Collider collider in bombColliders)
            {
                if (collider.gameObject.tag.Equals(TagHolder.running_drone))
                {
                    poolMech.enqueue(collider.gameObject, runningDroneParent);
                }
                else if (collider.gameObject.tag.Equals(TagHolder.rotating_drone))
                {
                    poolMech.enqueue(collider.transform.parent.gameObject, rotatingDroneParent);
                }
                else if (collider.gameObject.tag.Equals(TagHolder.rotating_enemy))
                {
                    poolMech.enqueue(collider.transform.parent.gameObject, rotatingEnemyDroneParent);
                }

                else if (collider.gameObject.tag.Equals(TagHolder.AI_drone))
                {
                    poolMech.enqueue(collider.gameObject, AIDroneParent);
                }
                else if (collider.gameObject.tag.Equals(TagHolder.running_health_drone))
                {
                    poolMech.enqueue(collider.gameObject, runningHealthDroneParent);
                    manager.Instance.incHealth(gameParameters.health_point);
                }
                else if (collider.gameObject.tag.Equals(TagHolder.bomb_drone))
                {
                    poolMech.enqueue(collider.gameObject, bombDroneParent);
                }

                // Destroy(collider.gameObject);
                bombedObjectNum++;

            }

            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point * bombedObjectNum);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point * bombedObjectNum);
            }
            else manager.Instance.incScore(gameParameters.score_point * bombedObjectNum);
            poolMech.enqueue(collision.transform.gameObject, bombDroneParent);
        }
        else manager.Instance.setCombo();

        poolMech.enqueue(gameObject, bulletParent);


    }
}