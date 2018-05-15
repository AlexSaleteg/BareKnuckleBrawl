using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCustom : MonoBehaviour {

    public GameObject playerM;
    public GameObject playerF;

    void Awake ()
    {
        if (PlayerPrefs.GetInt("Player" + playerM.name[6] + "BodyType", 0) == 0)
        {
            playerF.SetActive(false);
        }
        else
        {
            playerM.SetActive(false);
        }
	}
}
