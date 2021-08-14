using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    public float followSmoothing = 5f;


    void Update()
    {

        if(transform.position != (target.transform.position + offset))
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + offset, followSmoothing);
        }
    }
}
