using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_gun : MonoBehaviour
{
    referancePoint shootingPosition;
    //[SerializeField] private Vector3 referenceObjectPoint;
    [SerializeField] private float timer = 5;
    private float bullet_time;
    [SerializeField] private GameObject enemy_bullet; //prefab for enemy bullets
    [SerializeField] private Transform enemy_spawn_point; 
    [SerializeField] private float enemy_speed;

    void Start()
    {
        shootingPosition = FindObjectOfType<referancePoint>();
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
        Rigidbody bulletRig = bulletobj.GetComponent<Rigidbody>();
        bulletRig.AddForce(bulletRig.transform.forward * enemy_speed);

    }
}
