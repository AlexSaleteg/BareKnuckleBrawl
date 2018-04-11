using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTrigger : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            HealthBarScriptt.health -= 10f;
        }
    }

}
