using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCenter : MonoBehaviour
{
    [SerializeField] private float rotationSpeed; // rotate around itself

    poolMechanism poolMech;

    // Start is called before the first frame update
    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();

        transform.position = new Vector3(0,0,0);
        transform.GetChild(0).transform.position = new Vector3(Random.Range(-100, -60), Random.Range(10, 25), 0);
    }
    // Update is called once per frame
        void Update()
    {
        transform.Rotate(new Vector3(0, rotationSpeed, 0) * Time.deltaTime); // rotate around itself

        poolMech.dequeue(gameObject);
    }
}
