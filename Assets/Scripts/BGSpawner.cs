using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    public GameObject Camera;
    public float ParallexEffect;
    private float Width, PositionX;
    // Start is called before the first frame update
    void Start()
    {
        Width = GetComponent<SpriteRenderer>().bounds.size.x;
        PositionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float parallexDistance = Camera.transform.position.x * ParallexEffect;
        float RemainingDistance = Camera.transform.position.x * (1 - ParallexEffect);

        transform.position = new Vector3(PositionX + parallexDistance,transform.position.y,transform.position.z);

        if (RemainingDistance > PositionX + Width)
        {
            PositionX += Width;
        }
    }
}
