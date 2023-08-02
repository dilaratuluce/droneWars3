using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class referancePoint : MonoBehaviour
{
    // referencePoint is created to control the enemy's target point to hit the player
    public Vector3 getPosition()
    {
        return transform.position;
    }
}