using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing_health : MonoBehaviour
{
    [SerializeField] float pos_x;
    [SerializeField] float pos_y;
    [SerializeField] float pos_z;

    poolMechanism poolMech;

    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();
        transform.position = new Vector3(pos_x, pos_y, pos_z);
    }
}
