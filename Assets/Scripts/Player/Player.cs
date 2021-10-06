using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    

    PlayerControls controls;
    PlayerMovement playerMovement;
    public PlayerData PlayerData;
    CharacterController charController;
    Health health;

    #region variables
    public int Level { get { return level; } }
    int level = 1;



    public float AbilityResource { get { return abilityResource; } }
    float resourceMax = 100f;
    float abilityResource;
    public float resourceGainPerSec = 5f;
    public bool regenResource = true;

    public bool IsDead { get { return isDead; } }
    bool isDead;
    #endregion


    private void Awake()
    {
        //enemyLayer = LayerMask.GetMask("Enemy");
        controls = new PlayerControls();
        charController = GetComponent<CharacterController>();
        playerMovement = GetComponent<PlayerMovement>();
        health = GetComponent<Health>();
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
      

        if(!isDead)
        {
            if (health.isDead)
            {
                isDead = true;
            }
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

    //PUT THIS IN A UTILS CLASS
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


}
