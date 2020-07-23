using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;

    [Space(15)]
    public bool stopAtAngle = false;
    [Range(0.0f, 359.0f)]
    public float stopAngle;

    void Update()
    {
        transform.Rotate(transform.up * (rotationSpeed * Time.deltaTime), Space.World);
    }
}
