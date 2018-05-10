using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public float player1Wins = 0;
    public float player2Wins = 0;
    private static int Player_1_Win = 0;
    private static int Player_2_Win = 0;
    private float Timer = 60;
    public float PauseTimer = 0;
    private Text timerText;
    private TakeDamage Player_1_HP;
    private TakeDamage Player_2_HP;
    public Slider Player_1_MaxHP;
    public Slider Player_2_MaxHP;
    public GameObject canvas;
    public GameObject canvas2;
    public GameObject canvas3;
    public GameObject canvas4;
    public Slider Player_1_HP_Slider;
    public Slider Player_2_HP_Slider;
    private int scene;


    void Start()
    {
        timerText = GetComponent<Text>();
        Player_1_HP = GameObject.Find("Player1").GetComponent<TakeDamage>();
        Player_2_HP = GameObject.Find("Player2").GetComponent<TakeDamage>();
        scene = SceneManager.GetActiveScene().buildIndex;
    }
 
    void Update()
    {
        Timer -= Time.deltaTime;
        timerText.text = Timer.ToString("f0");
        
        if (Timer <= 0.001)
        {
            if (Player_1_HP.health > Player_2_HP.health)
            {
                Player_1_Win = Player_1_Win + 1;
                print("Player 1 wins a ROUND");
                SceneManager.LoadScene(scene);
                canvas.SetActive(true);
            }
            else if (Player_2_HP.health > Player_1_HP.health)
            {
                Player_2_Win = Player_2_Win + 1;
                print("Player 2 wins a ROUND");
                SceneManager.LoadScene(scene);
                canvas2.SetActive(true);
            }
            else
            {
                SceneManager.LoadScene(scene);
            }
        }
        if (Player_1_HP.health <= 0.001f)
        {
            player2Wins += Time.deltaTime;
            PauseTimer += Time.deltaTime;
            canvas2.SetActive(true);
        }
        else if (Player_2_HP.health <= 0.001)
        {
            player1Wins += Time.deltaTime;
            PauseTimer += Time.deltaTime;
            canvas.SetActive(true);
        }
        if (Player_2_Win == 2)
        {
            canvas4.SetActive(true);
            print("Player 2 wins the MATCH");
            PlayerPrefs.DeleteAll();
           
        }
        if (Player_1_Win == 2)
        {
            canvas3.SetActive(true);
            print("Player 1 wins the MATCH");
            PlayerPrefs.DeleteAll();  
        }
        if (player2Wins >= 5)
        {
            Player_2_Win = Player_2_Win + 1;
            print("Player 2 wins a ROUND");
        }
        if (player1Wins >= 5)
        {
            Player_1_Win = Player_1_Win + 1;
            print("Player 1 wins a ROUND");
        }
        if (player1Wins >= 5 || player2Wins >= 5)
        {
            player2Wins = Time.deltaTime;
            player1Wins = Time.deltaTime;
        }
        if (PauseTimer >= 5 && Player_2_Win == 1 && Player_1_Win != 2)
        {
            SceneManager.LoadScene(scene);
        }
        if (PauseTimer >= 5 && Player_1_Win == 1 && Player_2_Win != 2)
        {
            SceneManager.LoadScene(scene);
        }
        if (Player_1_Win == 2 && PauseTimer >= 9)
        {
            Player_2_Win = 0;
            Player_1_Win = 0;
            SceneManager.LoadScene(scene);
        }
        if (Player_2_Win == 2 && PauseTimer >= 9)
        {
            Player_2_Win = 0;
            Player_1_Win = 0;
            SceneManager.LoadScene(scene);
        }
        if(Player_1_Win == 1)
        {
            canvas.SetActive(true);
        }
        if (Player_2_Win == 1)
        {
            canvas2.SetActive(true);
        }
    }
}
