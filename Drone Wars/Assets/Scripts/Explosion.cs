using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    bulletProjectile bulletScript;
    poolMechanism poolMech;

    [SerializeField] float explosionEndTime;
    [SerializeField] GameObject ExplosionParent;

    void OnEnable()
    {
        poolMech = FindObjectOfType<poolMechanism>();
        bulletScript = FindObjectOfType<bulletProjectile>();

        //transform.position = bulletScript.getPosition();

        Invoke("Destroy", explosionEndTime);
    }

    void Destroy()
    {
        poolMech.enqueue(gameObject, ExplosionParent);
    }

    // Update is called once per frame
    void Update()
    {

    }
}