using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCustom : MonoBehaviour {

    public MeshCustomization player;
    public PlayerVisualsData data;

    void Start ()
    {
        player.RecolorSkin(data.GetSkinColor());
        player.ChangeMoustache(data.GetMoustache());
        player.RecolorMoustache(data.GetMoustacheColor());
	}
}
