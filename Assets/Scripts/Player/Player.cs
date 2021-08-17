using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController charController;
    PlayerControls controls;
    AudioSource attackSound;
    PlayerMovement playerMovement;

    private void Awake()
    {
        //enemyLayer = LayerMask.GetMask("Enemy");
        controls = new PlayerControls();
        attackSound = GetComponent<AudioSource>();
        charController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        controls.Gameplay.PrimaryAttack.performed += ctx => UseAttackA();
    }

    private void Update()
    {
        
    }
    #region COMBAT CONTROLS

    void UseAttackA()
    {
        attackSound.Play();
        playerMovement.EndSprinting(-0.05f);
    }

    GameObject GetClosestTarget()
    {
        GameObject target = null;
        //foreach()
        return target;

    }
    #endregion

}
