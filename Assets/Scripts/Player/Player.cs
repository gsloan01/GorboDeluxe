using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform weaponTransforms;
    public PlayerData PlayerData;
    public Slider resourceSlider;
    public GameObject GameUI;
    public GameObject DeathUI;
    #region Components
    CharacterController charController;
    PlayerControls controls;
    PlayerMovement playerMovement;
    Health health;
    public Animator Animator { get { return animator; } }
    Animator animator;

    
    public PlayerAnimController animController;
    public HotbarController hotbarController;
    #endregion
    #region variables
    //MAKE THIS WORK
    public int Level { get { return level; } }
    int level = 1;



    public float AbilityResource { get { return abilityResource; } }
    float resourceMax = 100f;
    float abilityResource;
    public float resourceGainPerSec = 5f;
    public bool regenResource = true;
    float abil1timer = 0;
    float abil2timer = 0;
    float abil3timer = 0;
    float abil4timer = 0;

    List<GameObject> weaponBuffs = new List<GameObject>();


    public bool isDead;
    #endregion

    //TURN THIS INTO AN ABILITY MANAGER
    PlayerAbility ability1;
    PlayerAbility ability2;
    PlayerAbility ability3;
    PlayerAbility ability4;

    public GameObject DeathSFX;

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
        animator = GetComponentInChildren<Animator>();
        health = GetComponent<Health>();

        controls.Gameplay.Skill1.performed += ctx => UseSkill1();
        controls.Gameplay.Skill2.performed += ctx => UseSkill2();
        controls.Gameplay.Skill3.performed += ctx => UseSkill3();
        controls.Gameplay.Skill4.performed += ctx => UseSkill4();

        ability1 = PlayerData.ability1;
        ability2 = PlayerData.ability2;
        ability3 = PlayerData.ability3;
        ability4 = PlayerData.ability4;

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
        #region Ability Cooldowns
        if (ability1.onCooldown)
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
        if (ability4.onCooldown)
        {
            abil4timer += Time.deltaTime;
            if (abil4timer >= ability4.cooldown)
            {
                abil4timer = 0;
                ability4.onCooldown = false;
            }
        }
        #endregion

        if(!isDead)
        {
            if (health.isDead)
            {

                isDead = true;
                animController.DeathAnim(isDead);
                animController.IdleAnim(false);
                if (DeathSFX != null) Instantiate(DeathSFX, transform);
                GameUI.SetActive( false);
                DeathUI.SetActive(true);
                
            }
        }
        if(isDead)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, .01f, 1 * Time.deltaTime);

        }

        for (int i = 0; i < weaponBuffs.Count; i++)
        {
            if(weaponBuffs[i] == null)
            {
                weaponBuffs.RemoveAt(i);
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

    public void AddWeaponBuff(GameObject buff)
    {
        weaponBuffs.Add(buff);
        //buff.transform.SetParent(weaponTransforms);
        
    }

    #region COMBAT CONTROLS


    //For the warrior this will always be a sort of melee attack
    void UseSkill1()
    {
        if(!isDead)
        {
            if (ability1 == null)
            {
                if (GameSettings.Instance.debug) Debug.Log("No ability bound to Skill1");
            }
            else
            {
                if (ability1.onCooldown)
                {
                    if (GameSettings.Instance.debug) Debug.Log($"{ability1.name} is on cooldown for {abil1timer} sec...");
                }
                else if (abilityResource - ability1.cost >= 0)
                {
                    hotbarController.StartCooldown(1, ability1.cooldown);
                    List<Damage> buffs = new List<Damage>();
                    if (weaponBuffs.Count > 0)
                    {
                        foreach (GameObject g in weaponBuffs)
                        {
                            foreach (Damage d in g.GetComponent<WeaponBuff>().buff.damages)
                            {
                                buffs.Add(d);
                            }

                        }
                    }
                    animController.ThrustAttackAnim();
                    ability1.Activate(this, buffs);
                    abilityResource -= ability1.cost;
                    ability1.onCooldown = true;
                }

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
                hotbarController.StartCooldown(2, ability2.cooldown);

                List<Damage> buffs = new List<Damage>();
                if (weaponBuffs.Count > 0)
                {
                    foreach (GameObject g in weaponBuffs)
                    {
                        foreach (Damage d in g.GetComponent<WeaponBuff>().buff.damages)
                        {
                            buffs.Add(d);
                        }

                    }
                }
                animController.ThrustAttackAnim();
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
                hotbarController.StartCooldown(3, ability3.cooldown);

                List<Damage> buffs = new List<Damage>();
                if (weaponBuffs.Count > 0)
                {
                    foreach (GameObject g in weaponBuffs)
                    {
                        foreach (Damage d in g.GetComponent<WeaponBuff>().buff.damages)
                        {
                            buffs.Add(d);
                        }

                    }
                }
                animController.ShieldAttackAnim();
                ability3.Activate(this);
                abilityResource -= ability3.cost;
                ability3.onCooldown = true;
            }

        }
    }

    void UseSkill4()
    {
        if (ability4 == null)
        {
            if (GameSettings.Instance.debug) Debug.Log("No ability bound to Skill4");
        }
        else
        {
            if (ability4.onCooldown)
            {
                if (GameSettings.Instance.debug) Debug.Log($"{ability4.name} is on cooldown for {abil4timer} sec...");
            }
            else if (abilityResource - ability4.cost >= 0)
            {
                hotbarController.StartCooldown(4, ability4.cooldown);

                List<Damage> buffs = new List<Damage>();
                if (weaponBuffs.Count > 0)
                {
                    foreach (GameObject g in weaponBuffs)
                    {
                        foreach (Damage d in g.GetComponent<WeaponBuff>().buff.damages)
                        {
                            buffs.Add(d);
                        }

                    }
                }
                animController.YellAnim();
                ability4.Activate(this);
                abilityResource -= ability4.cost;
                ability4.onCooldown = true;
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
