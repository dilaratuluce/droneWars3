using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{
    //This script represents the behavior of the shots (lasers) fired by the Ray Gun.
    [SerializeField] private Vector3 m_target; //target position of the shot
    //[SerializeField] private GameObject collisionExplosion;
    [SerializeField] private float speed;


    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
        transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

        float step = speed * Time.deltaTime;

        if (m_target != null) // if we hit something
        {
            if (transform.position == m_target)
            {

                return;
            }
            transform.position = Vector3.MoveTowards(transform.position, m_target, step);
        }

    }

    public void setTarget(Vector3 target)
    {
        m_target = target;
    }
    //When a ray hits an object, the RayGun.cs script calls this method to set the hit point as the target position for the shot.



}