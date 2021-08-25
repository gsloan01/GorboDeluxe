using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowObject : MonoBehaviour
{
    public GameObject CreateFX;
    public GameObject DestroyFX;
    public Rigidbody rb;

    public float flySpeed;

    private void Start()
    {
        //Instantiate(CreateFX);
        //Destroy(CreateFX, .4f);
        //Set Velocity to a semi-high value to shoot forward
        rb.velocity = Vector3.forward * 5f;
    }

}
