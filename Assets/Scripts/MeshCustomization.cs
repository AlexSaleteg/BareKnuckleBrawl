using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class MeshCustomization : MonoBehaviour
{
    public Database source;

    void Awake()
    {
        RecolorSkin(PlayerPrefs.GetInt("Player" + gameObject.name[6] + "SkinColor", 0));
        ChangeMoustache(PlayerPrefs.GetInt("Player" + gameObject.name[6] + "Moustache", 1));
        RecolorMoustache(PlayerPrefs.GetInt("Player" + gameObject.name[6] + "MoustacheColor", 0));
    }
    public void ChangeSkin(int index)
    {
        
    }

    public void RecolorSkin(int index)
    {
        GameObject child = transform.Find("Meshes").gameObject;
        SpriteMeshInstance[] meshes = child.GetComponentsInChildren<SpriteMeshInstance>();
        foreach (SpriteMeshInstance mesh in meshes)
        {
            if (mesh.gameObject.name != "MEyes")
            {
                mesh.color = source.skinColors[index];
            }
        }
        transform.Find("Bones/HipBone/Spine/NeckBone/LShoulderBone/LUpperArmBone/LLowerArmBone/LHandBone/ZaHando").GetComponent<SpriteRenderer>().color = source.skinColors[index];
    }

    public void RecolorMoustache(int index)
    {
        GameObject child = transform.Find("Meshes/MHead").gameObject;
        SpriteMeshInstance[] hair = child.GetComponentsInChildren<SpriteMeshInstance>();
        foreach (SpriteMeshInstance mesh in hair)
        {
            if (mesh.gameObject.tag == "Hair")
            {
                mesh.color = source.moustacheColors[index];
            }
        }
        child = transform.Find("Bones/HipBone/Spine/NeckBone/BackHead/HeadBone").gameObject;
        SpriteRenderer[] meshes = child.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer mesh in meshes)
        {
            if (mesh.gameObject.tag == "Moustache")
            {
                mesh.color = source.moustacheColors[index];
            }
        }
        transform.Find("Meshes/MHead/MEyebrows").gameObject.GetComponent<SpriteMeshInstance>().color = source.moustacheColors[index];
    }

    public void ChangeMoustache(int index)
    {
        GameObject child = transform.Find("Bones/HipBone/Spine/NeckBone/BackHead/HeadBone").gameObject;
        SpriteRenderer[] meshes = child.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer moustache in meshes)
        {
            if (moustache.gameObject.tag == "Moustache")
            {
                moustache.gameObject.SetActive(false);
            }
        }
        child.transform.Find("Moustache" + index).gameObject.SetActive(true);
    }
     public void ChangeHair(int index)
    {
        GameObject child = transform.Find("Meshes/MHead").gameObject;
        SpriteMeshInstance[] hair = child.GetComponentsInChildren<SpriteMeshInstance>();
        foreach (SpriteMeshInstance mesh in hair)
        {
            if (mesh.gameObject.tag == "Hair")
            {
                mesh.gameObject.SetActive(false);
            }
            child.transform.Find("Hair" + index).gameObject.SetActive(true);
        }
    }
}