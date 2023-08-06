using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_gun : MonoBehaviour
{
    referancePoint shootingPosition;
    //[SerializeField] private Vector3 referenceObjectPoint;
    [SerializeField] private float timer = 5;
    private float bullet_time;
    [SerializeField] private GameObject enemy_bullet; //prefab for enemy bullets
    [SerializeField] private Transform enemy_spawn_point; 
    [SerializeField] private float enemy_speed;

    Slider EnemyHealthSlider;

    void OnEnable()
    {
        shootingPosition = FindObjectOfType<referancePoint>();

        EnemyHealthSlider = gameObject.GetComponentsInChildren<Slider>()[0];
        EnemyHealthSlider.value = 100;
    }

    private void Update()
    {

        transform.LookAt(shootingPosition.getPosition());
        //this is used to get the player's position, and the enemy gun continuously rotates towards that position

        ShootAtPlayer();

    }
    void ShootAtPlayer()
    {
        bullet_time -= Time.deltaTime;
        if (bullet_time > 0) return;
        bullet_time = timer;
        GameObject bulletobj = Instantiate(enemy_bullet, enemy_spawn_point.transform.position, enemy_spawn_point.transform.rotation) as GameObject;
        Rigidbody bulletRig = bulletobj.GetComponent<Rigidbody>(); // bullet object'in scriptinde olsun, rigitbody çekme sürekli
        bulletRig.AddForce(bulletRig.transform.forward * enemy_speed);

    }
}
