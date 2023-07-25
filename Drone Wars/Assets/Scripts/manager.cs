using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class manager : MonoBehaviour
{
    private int health;
    private int score;
    //private int enemy_health;
    //private int rotating_enemy_health;
    //[SerializeField] Slider rotating_enemy_slider;
    [SerializeField] Slider enemy_slider;
    [SerializeField] Slider slider;
    public TMP_Text scoreText;

    void Start()
    {
        //enemy_slider.maxValue = 100;
        slider.maxValue = 100;
        //rotating_enemy_slider.maxValue = 100;
        //setRotatingEnemyHealth(100);
        //setEnemyHealth(100);
        setHealth(100);
        setScore(0);
    }

    /*public float getRotatingEnemyHealth()
    {
        return rotating_enemy_health;
    }
    void setRotatingEnemyHealth(int val)
    {
        if (val >= 100)
        {
            rotating_enemy_health = 100;
        }
        else
        {
            rotating_enemy_health = val;
        }
        rotating_enemy_slider.value = rotating_enemy_health;

    }
    public float decRotatingEnemyHealth(int val)
    {
        setRotatingEnemyHealth(rotating_enemy_health - val);
        return rotating_enemy_health;
    }
    public float getEnemyHealth()
    {
        return enemy_health;
    }
    void setEnemyHealth(int val)
    {
        if (val >= 100)
        {
            enemy_health = 100;
        }
        else
        {
            enemy_health = val;
        }
        enemy_slider.value = enemy_health;

    }
    public float decEnemyHealth(int val)
    {
        setEnemyHealth(enemy_health - val);
        return enemy_health;
    }*/
    public float getHealth()
    {
        return health;
    }
    public float incHealth(int val)
    {
        setHealth(health + val);
        return health;
    }
    public float decHealth(int val)
    {
        setHealth(health - val);
        return health;
    }
    void setHealth(int val)
    {
        if(val >= 100)
        {
            health = 100;            
        }
        else
        {
            health = val;
        }
        slider.value = health;

    }
    public float incScore(int val)
    {
        setScore(score + val);
        return score;
    }
    void setScore(int val)
    {
        score = val;
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        
    }
}
