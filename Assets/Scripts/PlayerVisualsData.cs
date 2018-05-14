using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 1)]
public class PlayerVisualsData : ScriptableObject {

    private int moustache = 1;
    private int moustacheColor = 0;
    private int skinColor = 0;
    //static PlayerVisualsData _instance;
    //public PlayerVisualsData Instance {  get
    //    {
    //        if (!_instance)
    //        {
    //            _instance = FindObjectOfType<PlayerVisualsData>();
    //        }
    //        if (!_instance)
    //        {
    //            _instance = CreateDef
    //        }
    //    } }
    public void SetMoustache(int index)
    {
        moustache = index;
    }

    public void SetMoustacheColor(int index)
    {
        moustacheColor = index;
    }

    public void SetSkinColor(int index)
    {
        skinColor = index;
    }

    public int GetMoustache()
    {
        return moustache;
    }

    public int GetMoustacheColor()
    {
        return moustacheColor;
    }

    public int GetSkinColor()
    {
        return skinColor;
    }
}
