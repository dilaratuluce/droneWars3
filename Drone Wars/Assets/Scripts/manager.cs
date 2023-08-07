using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class manager : MonoBehaviour
{
    public static manager Instance { get; private set; }
    private int health;
    private int score;
    private int combo;
    [SerializeField] GameObject player;
    [SerializeField] private Slider enemy_slider;
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text comboText;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);// we do not want to destroy first instance.
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        combo = 0;
        slider.maxValue = gameParameters.health_max;
        setHealth(gameParameters.health_max);
        setScore(0);
    }

    public int getCombo()
    {
        return combo;
    }
    public int incCombo()
    {
        combo++;
        comboText.text = TagHolder.combo + combo;
        return combo;

    }
    public int setCombo()
    {
        combo = 0;
        comboText.text = TagHolder.combo + combo;
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
    public void setHealth(int val)
    {
        if (val >= gameParameters.health_max)
        {
            health = gameParameters.health_max;
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
    public void setScore(int val)
    {
        score = val;
        scoreText.text = TagHolder.score + score;
    }
    public Vector3 getPosition()
    {
        return player.transform.position;
    }

    void Update()
    {

    }
}
