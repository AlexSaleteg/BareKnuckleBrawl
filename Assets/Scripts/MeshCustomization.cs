using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class MeshCustomization : MonoBehaviour
{


    public void ChangeSkin(int index)
    {
        GameObject child = transform.Find("Meshes").gameObject;
        SpriteMeshAnimation[] meshes = child.GetComponentsInChildren<SpriteMeshAnimation>();
        foreach (SpriteMeshAnimation mesh in meshes)
        {
            mesh.frame = index;
        }
    }
    public void ChangeMoustache(int index)
    {
        transform.Find("Meshes/Head/Moustache").gameObject.GetComponent<SpriteMeshAnimation>().frame = index;
    }

}