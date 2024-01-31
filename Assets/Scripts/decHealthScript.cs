using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class decHealthScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(TagHolder.enemy_bullet)) // tag holder cs dosyası oluştur, oradan çek, tagHolder.enemyBullet gibi çek
        {
            manager.Instance.decHealth(gameParameters.enemy_bullet_damage);
        }
    }

    void Update()
    {
        if(manager.Instance.getHealth() <= 0) // player is dead
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }


}

