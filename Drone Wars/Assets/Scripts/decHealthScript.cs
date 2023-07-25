using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class decHealthScript : MonoBehaviour
{
    manager health;

    void Start()
    {
        health = FindObjectOfType<manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("enemy_bullet"))
        {
            health.decHealth(5);
        }
    }

    void Update()
    {
        if(health.getHealth() <= 0)
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }


}

