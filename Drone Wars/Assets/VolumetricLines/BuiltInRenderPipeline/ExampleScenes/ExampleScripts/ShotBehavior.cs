using UnityEngine;
using System.Collections;

public class ShotBehavior : MonoBehaviour
{

    [SerializeField] private Vector3 m_target;
    [SerializeField] private GameObject collisionExplosion;
    [SerializeField] private float speed;



    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 300f;// The step size is equal to speed times frame time.
        transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);

        float step = speed * Time.deltaTime;

        if (m_target != null)
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



}