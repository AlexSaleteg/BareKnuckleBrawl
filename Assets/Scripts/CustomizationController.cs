using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizationController : MonoBehaviour {

    public GameObject dial;
    public MeshCustomization player;
    public PlayerVisualsData data;
    public string choose;
    public string next;

    private int skinColor = 0;
    private int moustache = 1;
    private int moustacheColor = 0;
    private int phase = 0;


	void Update ()
    {

        if (Input.GetKeyDown(next))
        {
            phase++;
            if (phase > 2)
            {
                phase = 0;
            }
        }
        if (Input.GetKeyDown(choose))
        {
            if (phase == 0)
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
            if (phase == 1)
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
            if (phase == 2)
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
