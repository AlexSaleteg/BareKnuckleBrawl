using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class MeshCustomization : MonoBehaviour
{
    public Database source;

    public int skincolor;
    public int haircolor;

    void Start()
    {
        RecolorSkin(skincolor);
        RecolorMoustache(haircolor);
    }
    //public void ChangeSkin(int index)
    //{
    //    GameObject child = transform.Find("Meshes").gameObject;
    //    SpriteMeshAnimation[] meshes = child.GetComponentsInChildren<SpriteMeshAnimation>();
    //    foreach (SpriteMeshAnimation mesh in meshes)
    //    {
    //        mesh.frame = index;
    //    }
    //}
    public void ChangeMoustache(int index)
    {
        transform.Find("Meshes/MHead/Moustache").gameObject.GetComponent<SpriteMeshAnimation>().frame = index;
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
        SpriteMeshInstance[] meshes = child.GetComponentsInChildren<SpriteMeshInstance>();
        foreach (SpriteMeshInstance mesh in meshes)
        {
            if (mesh.gameObject.tag == "Moustache")
            {
                mesh.color = source.moustacheColors[index];
            }
        }
        //transform.Find("Meshes/MHead/Moustache").gameObject.GetComponent<SpriteMeshInstance>().color = source.moustacheColors[index];
        transform.Find("Meshes/MHead/MEyebrows").gameObject.GetComponent<SpriteMeshInstance>().color = source.moustacheColors[index];
    }

}