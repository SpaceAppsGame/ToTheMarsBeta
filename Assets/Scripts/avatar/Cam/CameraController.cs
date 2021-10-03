using System;
using UnityEngine;

//apply to cam 
public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {     
        transform.position = player.transform.position + offset;
    }
}

