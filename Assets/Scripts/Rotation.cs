using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 20;

    void Update()
    {
        transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
    }
}
