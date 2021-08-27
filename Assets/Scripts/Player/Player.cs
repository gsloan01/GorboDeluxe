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
    PlayerAbility ability2;
    PlayerAbility ability3;
    
    public int Level { get { return level; } }
    int level = 1;
    PlayerClass playerClass = PlayerClass.Warrior;

    public float AbilityResource { get { return abilityResource; } }
    float resourceMax = 100f;
    float abilityResource;
    public float resourceGainPerSec = 5f;
    public bool regenResource = true;
    public Slider resourceSlider;
    float abil1timer = 0;
    float abil2timer = 0;
    float abil3timer = 0;

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
        controls.Gameplay.Skill2.performed += ctx => UseSkill2();
        controls.Gameplay.Skill3.performed += ctx => UseSkill3();

        ability1 = PlayerData.ability1;
        ability2 = PlayerData.ability2;
        ability3 = PlayerData.ability3;

        abilityResource = resourceMax;
        resourceSlider.maxValue = resourceMax;
        resourceSlider.value = abilityResource;
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
        if(ability1.onCooldown)
        {
            abil1timer += Time.deltaTime;
            if(abil1timer >= ability1.cooldown)
            {
                abil1timer = 0;
                ability1.onCooldown = false;
            }
        }
        if (ability2.onCooldown)
        {
            abil2timer += Time.deltaTime;
            if (abil2timer >= ability2.cooldown)
            {
                abil2timer = 0;
                ability2.onCooldown = false;
            }
        }
        if (ability3.onCooldown)
        {
            abil3timer += Time.deltaTime;
            if (abil3timer >= ability3.cooldown)
            {
                abil3timer = 0;
                ability3.onCooldown = false;
            }
        }
        ResourceManagement();
    }

    void ResourceManagement()
    {
        resourceSlider.value = AbilityResource;
        if(regenResource && AbilityResource <= resourceMax)
        {
            abilityResource += Time.deltaTime * resourceGainPerSec;
        }
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
            if(ability1.onCooldown)
            {
                if (GameSettings.Instance.debug) Debug.Log($"{ability1.name} is on cooldown for {abil1timer} sec...");
            }
            else if(abilityResource - ability1.cost >= 0)
            {
                ability1.Activate(this);
                abilityResource -= ability1.cost;
                ability1.onCooldown = true;
            }

        }
    }

    void UseSkill2()
    {
        if (ability2 == null)
        {
            if (GameSettings.Instance.debug) Debug.Log("No ability bound to Skill2");
        }
        else
        {
            if (ability2.onCooldown)
            {
                if (GameSettings.Instance.debug) Debug.Log($"{ability2.name} is on cooldown for {abil2timer} sec...");
            }
            else if (abilityResource - ability2.cost >= 0)
            {
                ability2.Activate(this);
                abilityResource -= ability2.cost;
                ability2.onCooldown = true;
            }

        }
    }

    void UseSkill3()
    {
        if (ability3 == null)
        {
            if (GameSettings.Instance.debug) Debug.Log("No ability bound to Skill3");
        }
        else
        {
            if (ability3.onCooldown)
            {
                if (GameSettings.Instance.debug) Debug.Log($"{ability3.name} is on cooldown for {abil3timer} sec...");
            }
            else if (abilityResource - ability3.cost >= 0)
            {
                ability3.Activate(this);
                abilityResource -= ability3.cost;
                ability3.onCooldown = true;
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
