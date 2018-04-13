using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public TakeDamage Player_1_HP;
    public TakeDamage Player_2_HP;
    public float Timer = 60;
    public Text timerText;


    void Start()
    {
        Player_1_HP = GameObject.Find("Player1").GetComponent<TakeDamage>();
        Player_2_HP = GameObject.Find("Player2").GetComponent<TakeDamage>();
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        timerText.text = Timer.ToString("f0");
        if (Timer <= 0.0f)
        {
            Timer = +60;
        }
        if (Player_1_HP.health == 0)
        {
            Player_1_HP.health = +11;
            Player_2_HP.health = +11;
            Timer = +60;
        }
        else if (Player_2_HP.health == 0)
        {
            Player_1_HP.health = +11;
            Player_2_HP.health = +11;
            Timer = +60;
        }
    }
}
