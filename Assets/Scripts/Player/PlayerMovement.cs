using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public float rotateRate = 720f;

    Vector3 position;

    void Update()
    {
        position = transform.position;
        InputHandling();
    }

    #region PLAYER INPUT
    void InputHandling()
    {
        //checking how much to move horizontally
        float horizontal = Input.GetAxis("Horizontal");
        //checking how much to move vertically
        float vertical = Input.GetAxis("Vertical");

        //if there is any input..
        if(horizontal >= 0.01f || vertical >= 0.01f)
        {
            transform.Translate(new Vector3(horizontal, 0, vertical) * speed);

        }
        
    }

    #endregion
}
