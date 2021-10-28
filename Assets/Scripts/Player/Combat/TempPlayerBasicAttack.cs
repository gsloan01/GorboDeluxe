using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPlayerBasicAttack : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            if (GameSettings.Instance.debug) Debug.Log("Hit an enemy");
            other.GetComponent<Health>().Apply(-100);
            

        }
    }
    private void OnDestroy()
    {
        
    }

}
