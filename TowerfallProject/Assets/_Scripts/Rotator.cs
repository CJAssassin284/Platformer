using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{

    public float rotSpeed = -1.75f;
    private float itemRotation = 10;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotSpeed * itemRotation * Time.deltaTime, 0);
    }
}
