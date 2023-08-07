using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
public class bulletProjectile : MonoBehaviour
{
    Rigidbody bulletRigidbody;
    [SerializeField] float bullet_speed;
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject health_explosionEffect;
    [SerializeField] private GameObject bomb_explosionEffect;
    [SerializeField] private ParticleSystem ImpactParticleSystem;
    [SerializeField] private GameObject health_plus; // health code line
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

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        bulletRigidbody.velocity = transform.forward * bullet_speed;
        AI_drone = FindObjectOfType<AI_drone>(); //doo
        combo = FindObjectOfType<Combo>();
        poolMech = FindObjectOfType<poolMechanism>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.transform.tag.Equals(TagHolder.running_drone))
        {
            //Destroy(collision.transform.gameObject); // destroy ve intantiate kullanmıyoruz, queue kullan; enqueue, dequeue

            Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
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
            //Destroy(collision.transform.gameObject); // destroy ve intantiate kullanmıyoruz, queue kullan; enqueue, dequeue

            Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
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
        else if (collision.transform.tag.Equals(TagHolder.rotating_enemy))
        {
            EnemyHealthSlider = collision.transform.gameObject.GetComponentsInChildren<Slider>()[0];
            if (EnemyHealthSlider.value > gameParameters.enemy_health_limit)
            {
                EnemyHealthSlider.value -= gameParameters.enemy_health_limit;

            }
            else
            {
                EnemyHealthSlider.value = 0;
                //collision.transform.gameObject.SetActive(false);
                Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
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

        else if (collision.transform.tag.Equals(TagHolder.AI_drone)) // doo
        {
            EnemyHealthSlider = collision.transform.gameObject.GetComponentsInChildren<Slider>()[0];
            if (EnemyHealthSlider.value > gameParameters.enemy_health_limit) // gameParameter.cs'e koy parametreleri, public sontant olarak koy, cs dosyaları büyük harfle başlasın
            {
                AI_drone = collision.transform.gameObject.GetComponent<AI_drone>();
                EnemyHealthSlider.value -= gameParameters.enemy_health_limit;
                AI_drone.changePosBool(true);

            }
            else
            {
                EnemyHealthSlider.value = 0;
                //Destroy(collision.transform.gameObject);

                Instantiate(explosionEffect, collision.transform.position, collision.transform.rotation);
                manager.Instance.incCombo();
                if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
                else if (manager.Instance.getCombo() == gameParameters.combo_limit)
                {
                    combo.Open();
                    manager.Instance.incScore(gameParameters.buffed_score_point);
                }
                else manager.Instance.incScore(gameParameters.score_point);

                poolMech.enqueue(collision.transform.gameObject, rotatingDroneParent); // new line

            }


        }

        /* else if (collision.transform.tag.Equals("health_drone"))
         {
             Debug.Log("health drone shooted");
             collision.transform.gameObject.SetActive(false);
             manager.Instance.incHealth(30);
             Instantiate(health_plus, collision.transform.position, collision.transform.rotation); // health code line
             Instantiate(health_explosionEffect, collision.transform.position, collision.transform.rotation);
            // StartCoroutine(ReactivateHealthDrone(collision.transform.gameObject));
             manager.Instance.incCombo();
             if (manager.Instance.getCombo() > 5) manager.Instance.incScore(10);
             else if (manager.Instance.getCombo() == 5)
             {
                 combo.Open();
                 manager.Instance.incScore(10);
             }
             else manager.Instance.incScore(5);
         }*/

        else if (collision.transform.tag.Equals(TagHolder.running_health_drone))
        {
            Debug.Log("running health drone shooted");

            Instantiate(health_plus, collision.transform.position, collision.transform.rotation); // health code line
            Instantiate(health_explosionEffect, collision.transform.position, collision.transform.rotation);

            manager.Instance.incHealth(gameParameters.health_point);
            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point);
            }
            else manager.Instance.incScore(gameParameters.score_point);

            poolMech.enqueue(collision.transform.gameObject, rotatingDroneParent); // new line

        }

        else if (collision.transform.tag.Equals(TagHolder.bomb_drone))
        {
            bombColliders = Physics.OverlapSphere(collision.transform.position, bombRadius);
            bombedObjectNum = 0;
            Instantiate(bomb_explosionEffect, collision.transform.position, collision.transform.rotation);
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


    }
}
