using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public PlayerData PlayerData;
    PlayerMovement playerMovement;
    CharacterController charController;
    Health health;

    #region variables
    public float AbilityResource { get { return abilityResource; } }
    float resourceMax = 100f;
    float abilityResource;
    public float resourceGainPerSec = 5f;
    public bool regenResource = true;

    #endregion


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
    }

    void FaceTarget(GameObject target)
    {
        
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
        }
    }

    


}
