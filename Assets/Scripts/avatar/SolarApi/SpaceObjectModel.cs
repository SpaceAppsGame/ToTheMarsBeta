using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceObjectModel : MonoBehaviour
{
    public ApiManagerBehaviour.SolarBody Body { get; set; }

    public float rotationSpeed = 10f;

    private Transform sunTransform;

    // Start is called before the first frame update
    void Start()
    {
        sunTransform = GameObject.FindGameObjectWithTag("Sun").transform;
    }
 
    void Update()
    {
        transform.RotateAround(sunTransform.position, -Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
