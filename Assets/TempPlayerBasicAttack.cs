using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerBasicAttack : MonoBehaviour
{
    private void Awake()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //Deal damage
        }
    }

}
