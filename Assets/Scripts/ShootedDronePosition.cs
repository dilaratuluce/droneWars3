using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootedDronePosition : MonoBehaviour
{
    Vector3 shootedDronePos;

    public Vector3 getDronePos()
    {
        return shootedDronePos;
    }

    public void setDronePos(Vector3 position)
    {
        shootedDronePos = position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
