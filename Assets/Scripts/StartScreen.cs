﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

	void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("CharacterSelect");
        }
    }
}
