using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class manager : MonoBehaviour
{
    private int health;
    private int score;
    [SerializeField] Slider slider;
    public TMP_Text scoreText;

    void Start()
    {
        slider.maxValue = 100;
        setHealth(100);
        setScore(0);
    }

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
