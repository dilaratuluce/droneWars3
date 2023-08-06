using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class manager : MonoBehaviour // mage game manager singleton
{
    private int health;
    private int score;
    private int combo;
    [SerializeField] private Slider enemy_slider;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text comboText;

    void Start()
    {
        combo = 0;
        slider.maxValue = 100;
        setHealth(100);
        setScore(0);
    }

    public int getCombo()
    {
        return combo;
    }
    public int incCombo()
    {
        combo++;
        comboText.text = "Combo: " + combo;
        return combo;

    }
    public int setCombo()
    {
        combo = 0;
        comboText.text = "Combo: " + combo;
        return combo;
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
        if (val >= 100)
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