using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy_bullet : MonoBehaviour
{
    // bütün oyunu çerçevele, bullet collider'a çarpınca kaybolsun
    [SerializeField] private float life = 3;
    private void Awake()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("player") || other.gameObject.tag.Equals("unshootable"))
        {
            gameObject.SetActive(false);
        }
    }
   

}
