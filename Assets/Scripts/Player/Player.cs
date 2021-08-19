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

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }
    private void Update()
    {
        
    }
    #region COMBAT CONTROLS

    void UseAttackA()
    {
        attackSound.Play();
        GameObject target = GetClosestTarget();
        if(GameSettings.Instance.debug)
        {
            string findString = (target != null) ? target.name + " found" : "No targets found";
            Debug.Log("USE ATTACK A : " + findString);
        }
        playerMovement.EndSprinting(-0.05f);
    }

    GameObject GetClosestTarget()
    {
        GameObject target = null;
        float closest = float.MaxValue;
        
        List<Enemy> enemies = EnemyManager.Instance.Enemies;
        if (enemies.Count == 0) return target;
        foreach (Enemy enemy in enemies)
        {
            float dist = Vector3.Distance(transform.position, enemy.transform.position);
            if (dist < closest)
            {
                target = enemy.gameObject;
                closest = dist;
            }
        }
        
        return target;

    }
    #endregion

}
