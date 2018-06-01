using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SliderScript : MonoBehaviour {

    public Slider slider;

	// Use this for initialization
	void Start () {

        slider.maxValue = PlayerPrefs.GetFloat ("MaxHealthbar");
       
	}
	
	// Update is called once per frame
	void Update () {
   // PlayerPrefs.SetFloat("MaxHealthbar1" + SceneManager.);
        
        //slider.maxValue = PlayerPrefs.GetFloat("MaxHealthbar1");
        //PlayerPrefs.Save();
    }
   
}

