using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {


    public GameObject menu;

    private AnimationScript1 player1;
    private AnimationScript1 player2;
    private int scene;

    void Start ()
    {
        player1 = GameObject.Find("Player1").GetComponent<AnimationScript1>();
        player2 = GameObject.Find("Player2").GetComponent<AnimationScript1>();
        scene = SceneManager.GetActiveScene().buildIndex;
        menu.SetActive(false);
	}
	
	
	void Update ()
    {
        if (menu.activeSelf)
        {
            if (Input.GetKeyDown(player1.lightAttack) || Input.GetKeyDown(player2.lightAttack))
            {
                PlayerPrefs.DeleteAll();
                Time.timeScale = 1;
                SceneManager.LoadScene(scene);
            }

            if (Input.GetKeyDown(player1.heavyAttack) || Input.GetKeyDown(player2.heavyAttack))
            {
                PlayerPrefs.DeleteAll();
                Time.timeScale = 1;
                SceneManager.LoadScene("TitleScreen");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
        }
	}
}
