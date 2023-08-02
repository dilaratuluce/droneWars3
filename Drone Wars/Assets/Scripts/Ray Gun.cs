using System.Collections;
using static UnityEngine.Rendering.SplashScreen;
using UnityEngine;

public class RayGun : MonoBehaviour
{
    [SerializeField] private float shootRate; //This is the rate at which the player can shoot rays
    private float m_shootRateTimeStamp; //This variable is used to keep track of the last time a shot was fired

    [SerializeField] private GameObject m_shotPrefab;//This is the prefab for the shot fired by the Ray Gun

    RaycastHit hit;
    float range = 1000.0f;


    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();
                m_shootRateTimeStamp = Time.time + shootRate;
            }
        }

    }

    void shootRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, range))
        {
            GameObject laser = GameObject.Instantiate(m_shotPrefab, transform.position, transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hit.point);
            GameObject.Destroy(laser, 0.1f);


        }

    }
    /*
     * This method creates a ray from the main camera's position to the mouse position on the screen using Camera.main.ScreenPointToRay(Input.mousePosition). 
     * It then checks if the ray hits any object within a range of 1000 units. 
     * If it does, it instantiates the m_shotPrefab (laser) at the Ray Gun's position 
     * and sets its target position to the point where the ray hit the object using laser.GetComponent<ShotBehavior>().setTarget(hit.point).
     */



}