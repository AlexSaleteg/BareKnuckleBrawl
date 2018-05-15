using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 1)]
public class PlayerVisualsData : ScriptableObject {

    private int moustache = 1;
    private int moustacheColor = 0;
    private int skinColor = 0;
    private int bodyType = 0;
    
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

    public void SetBodyType(int index)
    {
        bodyType = index;
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

    public int GetBodyType()
    {
        return bodyType;
    }
}
