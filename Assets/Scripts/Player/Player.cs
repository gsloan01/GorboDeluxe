using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    CharacterController charController;
    PlayerControls controls;
    PlayerMovement playerMovement;
    public PlayerData PlayerData;

    PlayerAbility ability1;

    public int Level { get { return level; } }
    int level = 1;
    PlayerClass playerClass = PlayerClass.Warrior;

    public enum PlayerClass
    {
        Warrior
    }

    private void Awake()
    {
        //enemyLayer = LayerMask.GetMask("Enemy");
        controls = new PlayerControls();
        charController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        controls.Gameplay.Skill1.performed += ctx => UseSkill1();
        ability1 = PlayerData.ability1;
        
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

    //For the warrior this will always be a sort of melee attack
    void UseSkill1()
    {
        if (ability1 == null)
        {
            if (GameSettings.Instance.debug) Debug.Log("No ability bound to Skill1");
        }
        else
        {
            ability1.Activate(this);
        }
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
    public GameObject GetClosestTarget(float maxRange = float.MaxValue)
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
        if (closest <= maxRange) return target;
        else return null;



    }
    #endregion

}
