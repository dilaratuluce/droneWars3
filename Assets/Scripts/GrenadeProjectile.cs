using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
public class GrenadeProjectile : MonoBehaviour
{
    Rigidbody bulletRigidbody;
    [SerializeField] float bullet_speed;
    Slider EnemyHealthSlider;
    AI_drone AI_drone; // doo // başında [SerField] vardı sildin
    [SerializeField] float rocketBombRadius;
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
    //[SerializeField] GameObject healthPlusCreator;
    //[SerializeField] GameObject explosionCreator;
    //[SerializeField] GameObject healthExplosionCreator;
    [SerializeField] GameObject rocketExplosionCreator;
    [SerializeField] GameObject bulletBringerParent;

    [SerializeField] Transform BulletSpawnPoint;

    public GameObject bulletParent; // (gun)

    [SerializeField] Transform look;
    //Vector3 shootedDronePosition;

    ShootedDronePosition shootedPosition;

    GrenadeLauncher my_gun;


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
        my_gun = FindObjectOfType<GrenadeLauncher>();

        /*Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
        {
            mouseWorldPosition = raycastHit.point;
        }

        Vector3 aimDir = (mouseWorldPosition - BulletSpawnPoint.position).normalized; */
        gameObject.transform.position = BulletSpawnPoint.position;
        gameObject.transform.rotation = look.rotation;
        bulletRigidbody.velocity = transform.forward * bullet_speed;


    }
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.tag.Equals(TagHolder.player) && !collision.transform.tag.Equals(TagHolder.unshootable))
        {
            bombColliders = Physics.OverlapSphere(collision.transform.position, rocketBombRadius);
            bombedObjectNum = 0;
            poolMech.dequeue2(rocketExplosionCreator, collision.transform.position);
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
                else if (collider.gameObject.tag.Equals(TagHolder.enemy))
                {
                    poolMech.enqueue(collider.gameObject, standingEnemyDroneParent);
                }
                else if (collider.gameObject.tag.Equals(TagHolder.health_drone))
                {
                    poolMech.enqueue(collider.gameObject, standingHealthDroneParent);
                    manager.Instance.incHealth(gameParameters.health_point);

                }
                else if (collider.gameObject.tag.Equals(TagHolder.bomb_drone))
                {
                    poolMech.enqueue(collider.gameObject, bombDroneParent);

                    bombedObjectNum++;
                }
                else if (collider.gameObject.tag.Equals(TagHolder.bullet_bringer))
                {
                    poolMech.enqueue(collider.gameObject, bulletBringerParent);
                    my_gun.setCurrentAmmoToMax();
                }



            }

            manager.Instance.incCombo();
            if (manager.Instance.getCombo() > gameParameters.combo_limit) manager.Instance.incScore(gameParameters.buffed_score_point * bombedObjectNum);
            else if (manager.Instance.getCombo() == gameParameters.combo_limit)
            {
                combo.Open();
                manager.Instance.incScore(gameParameters.buffed_score_point * bombedObjectNum);
            }
            else manager.Instance.incScore(gameParameters.score_point * bombedObjectNum);
            poolMech.enqueue(gameObject, bulletParent);
        }
        else if (collision.transform.tag.Equals(TagHolder.unshootable) || collision.transform.tag.Equals(TagHolder.limit) || collision.transform.tag.Equals(TagHolder.untagged))
        {
            manager.Instance.setCombo();
            poolMech.enqueue(gameObject, bulletParent);
        }




    }
}
