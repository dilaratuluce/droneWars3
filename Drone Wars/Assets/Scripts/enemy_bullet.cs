using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_bullet : MonoBehaviour
{
    [SerializeField] private Transform enemy_spawn_point;
    //[SerializeField] private GameObject player;

    Rigidbody bulletRigidbody;
    [SerializeField] float bullet_speed;

    poolMechanism poolMech;
    public GameObject bulletParent;


    // bütün oyunu çerçevele, bullet collider'a çarpınca kaybolsun
    //[SerializeField] private float life = 3;
    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();

        gameObject.transform.position = enemy_spawn_point.position;
        transform.LookAt(manager.Instance.getPosition());
        transform.localScale = new Vector3(0.3f,0.3f,0.3f); // bullet büyüklüğü
        //Vector3 aim = (enemy_spawn_point.position - player_position.position).normalized;
        bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bullet_speed;

    }

    private void OnTriggerEnter(Collider other) // trigger olunca enemy bullet yok oluyor ama decHelath scriptinde collide oluna player canı azalıyor, sorun mu?
    {
        if (other.gameObject.tag.Equals(TagHolder.player) || other.gameObject.tag.Equals(TagHolder.unshootable))
        {
            //gameObject.SetActive(false);
            poolMech.enqueue(gameObject, bulletParent);
        }
    }
   

}
