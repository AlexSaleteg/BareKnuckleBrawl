using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour {

   
    private Quaternion targetRotation;
    private float rotSpeed = 10f;
    private float startTime;

    void Start()
    {
        targetRotation = transform.rotation;
    }


    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, (Time.time - startTime)  / rotSpeed);
    }

    public void Rotate()
    {
        targetRotation *= Quaternion.Euler(0, 0, transform.rotation.z + 36);
        rotSpeed = 5f;
        startTime = Time.time;
    }

    public void Reset()
    {
        targetRotation.z = 0;
        rotSpeed = 5f;
        startTime = Time.time;
    }

    public void Shuffle()
    {
        StartCoroutine(ShuffleWork());
        rotSpeed = 5f;
        startTime = Time.time;
    }

    IEnumerator ShuffleWork()
    {
        targetRotation.z = 0;
        for (int i = 0; i < 4; i++)
        {
            targetRotation *= Quaternion.Euler(0, 0, transform.rotation.z + 180);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
