﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Confirmation : MonoBehaviour {

    public string player1Input;
    public string player2Input;
    public PlayerVisualsData player1;
    public PlayerVisualsData player2;
    public TraitDatabase traits;
    public string[] scenes;


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
            LoadRandomScene();
        }
    }

    void SaveData(PlayerVisualsData player)
    {
        PlayerPrefs.SetInt("Player" + player.name[6] + "BodyType", player.GetBodyType());
        PlayerPrefs.SetInt("Player" + player.name[6] + "MoustacheColor", player.GetMoustacheColor());
        PlayerPrefs.SetInt("Player" + player.name[6] + "SkinColor", player.GetSkinColor());
        PlayerPrefs.SetInt("Player" + player.name[6] + "Moustache", player.GetMoustache());
        PlayerPrefs.SetInt("Player" + player.name[6] + "Hair", player.GetHair());
        PlayerPrefs.SetInt("Player" + player.name[6] + "Trait", traits.RandomPresetIndex());
    }

    void LoadRandomScene()
    {
        SceneManager.LoadScene(scenes[Random.Range(0, scenes.Length)]);
    }
}
