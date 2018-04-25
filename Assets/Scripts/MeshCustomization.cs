using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Anima2D;

public class MeshCustomization : MonoBehaviour
{


    void Start()
    {

    }

    public void ChangeMesh(int index)
    {
        GameObject child = transform.Find("Meshes").gameObject;
        SpriteMeshAnimation[] meshes = child.GetComponentsInChildren<SpriteMeshAnimation>();
        foreach (SpriteMeshAnimation mesh in meshes)
        {
            mesh.frame = index;
        }
    }
}