using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_gun : MonoBehaviour
{
    [SerializeField] private float timer = 5;
    private float bullet_time;
    [SerializeField] private Transform enemy_spawn_point;

    poolMechanism poolMech;

    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();
        enemy_spawn_point.transform.position = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //this is used to get the player's position, and the enemy gun continuously rotates towards that position
        transform.LookAt(manager.Instance.getPosition());

        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bullet_time -= Time.deltaTime;
        if (bullet_time > 0) return;
        bullet_time = timer;

        poolMech.dequeue(gameObject);
        // GameObject bulletobj = Instantiate(enemy_bullet, enemy_spawn_point.transform.position, enemy_spawn_point.transform.rotation) as GameObject;
        // Rigidbody bulletRig = bulletobj.GetComponent<Rigidbody>(); // bullet object'in scriptinde olsun, rigitbody çekme sürekli
        // bulletRig.AddForce(bulletRig.transform.forward * enemy_speed);

    }

}
