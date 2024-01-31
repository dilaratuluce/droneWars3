using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_gun : MonoBehaviour
{

    //[SerializeField] private Vector3 referenceObjectPoint;
    [SerializeField] private float timer = 5;
    private float bullet_time;
    //[SerializeField] private GameObject enemy_bullet; //prefab for enemy bullets
    [SerializeField] private Transform enemy_spawn_point; 
    //[SerializeField] private float enemy_speed;

    [SerializeField] float pos_x;
    [SerializeField] float pos_y;
    [SerializeField] float pos_z;

    Slider EnemyHealthSlider;

    poolMechanism poolMech;

    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();
        transform.position = new Vector3(pos_x, pos_y, pos_z);

        EnemyHealthSlider = gameObject.GetComponentsInChildren<Slider>()[0];
        EnemyHealthSlider.value = gameParameters.enemy_health_max;
    }

    private void Update()
    {

        transform.LookAt(manager.Instance.getPosition());
        //this is used to get the player's position, and the enemy gun continuously rotates towards that position

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
