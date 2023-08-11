using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunBringerCenter : MonoBehaviour
{
    [SerializeField] private float rotationSpeed; // rotate around itself

    void OnEnable()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime); // rotate around itself

    }
}
