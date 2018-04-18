using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    int playerWins =0;
    static int Player_1_Win = 0;
    static int Player_2_Win = 0;
   public float Timer = 60;
    public float PauseTimer = 0;
    private Text timerText;
    private TakeDamage Player_1_HP;
    private TakeDamage Player_2_HP;

    // Use this for initialization
    void Start()
    {
        timerText = GetComponent<Text>();
        Player_1_HP = GameObject.Find("Player1").GetComponent<TakeDamage>();
        Player_2_HP = GameObject.Find("Player2").GetComponent<TakeDamage>();
    }

    // Update is called once per frame
    void Update()
    {

        Timer -= Time.deltaTime;
        timerText.text = Timer.ToString("f0");
        if (Timer <= 0.001)
        {
            if (Player_2_HP.health > Player_1_HP.health)
            {
                SceneManager.LoadScene("Round");
                Player_2_Win = Player_2_Win + 1;
                print("Player 2 wins a ROUND");
                
               
            }
        }
        if (Timer <= 0.001)
        {
            if (Player_1_HP.health > Player_2_HP.health)
            {
                SceneManager.LoadScene("Round");
                Player_1_Win = Player_1_Win + 1;
                print("Player 1 wins a ROOUND");
              
            }
        }
        else if (Player_1_HP.health == 0 || Input.GetKeyDown(KeyCode.K))
        {
            playerWins = 1;
            Player_2_Win = Player_2_Win + 1;
            print("Player 2 wins a ROUND");
        }
        else if (Player_2_HP.health == 0 || Input.GetKeyDown(KeyCode.L))
        {
            playerWins = 1;
            Player_1_Win = Player_1_Win + 1;
            print("Player 1 wins a ROOUND");
        }
        if (Player_2_Win == 2)
        {
            print("Player 2 wins the MATCH");
           
        }
        else if (Player_1_Win == 2)
        {
            print("Player 1 wins the MATCH");
            
        }
        if (playerWins == 1)
        {
            PauseTimer += Time.deltaTime;   
        }
 
        if (Player_1_Win== 1 & PauseTimer >= 5 || Player_2_Win == 1 & PauseTimer >= 5)
        {
            print("puff");
            SceneManager.LoadScene("Round");

        }
        if (Player_1_Win == 2 & PauseTimer >= 5 || Player_2_Win == 2 & PauseTimer >= 5)
        {
            print("puff");
            Player_2_Win = 0;
            Player_1_Win = 0;
            SceneManager.LoadScene("Round");

        }
        else if (Player_1_Win == 2 & Timer <= 0.001 || Player_2_Win == 2 & Timer <= 0.001)
        {
            print("puff");
            Player_2_Win = 0;
            Player_1_Win = 0;
            SceneManager.LoadScene("Round");

        }
    }
}
