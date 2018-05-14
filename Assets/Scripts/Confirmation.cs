using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Confirmation : MonoBehaviour {

    public string player1Input;
    public string player2Input;
    public PlayerVisualsData player1;
    public PlayerVisualsData player2;


    private bool player1Confirm = false;
    private bool player2Confirm = false;
	
	void Update ()
    {
		if (Input.GetKeyDown(player1Input))
        {
            player1Confirm = true;
        }
        if (Input.GetKeyDown(player2Input))
        {
            player2Confirm = true;
        }
        if (player1Confirm && player2Confirm)
        {
            PlayerPrefs.DeleteAll();
            SaveData(player1);
            SaveData(player2);
            SceneManager.LoadScene("Round");
        }
    }

    void SaveData(PlayerVisualsData player)
    {
        PlayerPrefs.SetInt("Player" + player.name[6] + "MoustacheColor", player.GetMoustacheColor());
        PlayerPrefs.SetInt("Player" + player.name[6] + "SkinColor", player.GetSkinColor());
        PlayerPrefs.SetInt("Player" + player.name[6] + "Moustache", player.GetMoustache());
    }
}
