using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationController : MonoBehaviour {

    public GameObject dial;
    public MeshCustomization playerM;
    public MeshCustomization playerF;
    public PlayerVisualsData data;
    public string choose;
    public string next;

    private MeshCustomization player;
    private int skinColor = 0;
    private int moustache = 1;
    private int moustacheColor = 0;
    private int phase = 0;

    void Start()
    {
        int bodytype = PlayerPrefs.GetInt("Player" + playerM.gameObject.name[6] + "BodyType", 0);
        if (bodytype == 0)
        {
            player = playerM;
            playerF.gameObject.SetActive(false);
        }
        else if (bodytype == 1)
        {
            player = playerF;
            playerM.gameObject.SetActive(false);
        }
        player.gameObject.SetActive(true);
        data.SetBodyType(bodytype);
    }

    void Update ()
    {

        if (Input.GetKeyDown(next))
        {
            phase++;
            if (phase > 3)
            {
                phase = 0;
            }
        }
        if (Input.GetKeyDown(choose))
        {
            if (phase == 0)
            {
                player.gameObject.SetActive(false);
                if (player == playerM)
                {
                    player = playerF;
                    data.SetBodyType(1);
                }
                else if(player == playerF)
                {
                    player = playerM;
                    data.SetBodyType(0);
                }
                player.gameObject.SetActive(true);
            }
            else if (phase == 1)
            {
                skinColor++;
                if (skinColor >= player.source.skinColors.Length)
                {
                    skinColor = 0;
                }
                data.SetSkinColor(skinColor);
                player.RecolorSkin(skinColor);
                player.RecolorMoustache(moustacheColor);
            }
            else if (phase == 2)
            {
                moustache++;
                if (moustache > 5)
                {
                    moustache = 1;
                }
                data.SetMoustache(moustache);
                player.ChangeMoustache(moustache);
                player.RecolorMoustache(moustacheColor);
            }
            else if (phase == 3)
            {
                moustacheColor++;
                if (moustacheColor >= player.source.moustacheColors.Length)
                {
                    moustacheColor = 0;
                }
                data.SetMoustacheColor(moustacheColor);
                player.RecolorMoustache(moustacheColor);
            }


        }
	}
}
