using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCombat : MonoBehaviour
{
    GameObject target;
    EnemyCombatData data;
    Enemy thisEnemy;
    Enemy.enemyState currentState = Enemy.enemyState.Idle;
    float timer;

    bool attacking = false;

    private void Awake()
    {
        thisEnemy = GetComponent<Enemy>();
        data = thisEnemy.data.combatData;

        thisEnemy.OnChangeState.AddListener(OnChangeState);
        thisEnemy.OnEnemyTargetChanged.AddListener(OnUpdateTarget);
    }
    
    AttackData GetRandomAttack()
    {
        return data.attacks[Random.Range(0, data.attacks.Count)];
    }
    void OnChangeState(Enemy.enemyState newState)
    {
        currentState = newState;
        if (currentState == Enemy.enemyState.Attacking) attacking = true;
        
    }
    void OnUpdateTarget(GameObject target)
    {
        this.target = target;
    }
    private void Update()
    {
        if(attacking)
        {
            Combat();
        }
    }
    private void Start()
    {
        target = PlayerManager.Instance.player;
    }
    public void Combat()
    {
        if(target)
        {
            if(GameSettings.Instance.debug) Debug.Log("Targeting " + target.gameObject.name);
            timer += Time.deltaTime;
            if (timer >= data.timeBetween)
            {

                
                timer = 0;

                Debug.Log($"{thisEnemy.data.name} has attacked {target.name}");

            }
        }
        else
        {
            timer = 0;
        }

    }
}
