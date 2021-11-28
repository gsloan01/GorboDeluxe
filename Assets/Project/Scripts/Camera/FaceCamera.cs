using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Camera cam;

    private void Awake()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        transform.LookAt(cam.transform, Vector3.up);
        
    }
}
