using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public EnemyData data;

    float bodyLifetime = 3.0f;

    public UnityEvent<enemyState> onChangeState;
    public UnityEvent<GameObject> OnEnemyTargetChanged;

    GameObject target;
    public float detectionRange = 8.0f;
    public float aggroLossRange = 15.0f;
    Health health;
    EnemyCombat enemyCombat;
    EnemyMovement enemyMovement;

    //Determines if the enemy has finished dying
    bool died;
    bool ranged;
    bool fleeable;

    float range;
    float bodyLifetimer = 0;

    public enemyState CurrentState { get { return currentState; } }
    enemyState currentState = enemyState.Idle;
    public enum enemyState
    {
        Idle, Wander, Flee, Chase, Attacking, Dead
    }


    private void Awake()
    {
        health = GetComponent<Health>();
        enemyCombat = GetComponent<EnemyCombat>();
        enemyMovement = GetComponent<EnemyMovement>();
        
        enemyMovement.Initialize(data.movementData);
    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.Instance.OnEnemyCreate.Invoke(this);

        //DATA GRABBING
        target = PlayerManager.Instance.player;
        ranged = enemyCombat.data.stayAtRange;
        fleeable = enemyCombat.data.flee;

        Debug.Log($"New Enemy Spawned : {data.name}, Ranged? : {(ranged ? "Yes" : "No")}");
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (currentState)
        {
            case enemyState.Idle:

                break;
            case enemyState.Wander:
                break;
            case enemyState.Flee:
                break;
            case enemyState.Chase:
                break;
            case enemyState.Attacking:
                break;
            case enemyState.Dead:
                EnemyManager.Instance.OnEnemyDeath.Invoke(this);
                break;
            default:
                break;
        }
        //else { enemyCombat.target = null; }
        //float distance = 0;
        //if(!died) distance = Vector3.Distance(target.transform.position, transform.position);

        //if (state != enemyState.Dead && health.isDead) state = enemyState.Dead;
        //if(!target && !damageable.isDead)
        //{
        //    state = enemyState.Idle;
        //}

        //switch (state)
        //{
        //    case enemyState.Idle:
        //        if(distance <= detectionRange)
        //        {
        //            state = enemyState.Chase;
        //        }
        //        break;
        //    case enemyState.Chase:
        //        if(GameSettings.Instance.debug) Debug.Log($"{gameObject.name} : MOVING");
        //        if (distance > range)
        //        {
        //            agent.SetDestination(target.transform.position);
        //            //agent.Move((target.transform.position - transform.position) * Time.deltaTime);
        //        }
        //        else if(fleeable && distance < range)
        //        {
        //            //run away to a safe distance
        //            if (GameSettings.Instance.debug)  Debug.Log("Running from " + target.name);
        //        }
        //        if(distance <= range)
        //        {
        //            state = enemyState.Attacking;
        //        }

        //        if( distance > detectionRange)
        //        {
        //            state = enemyState.Idle;
        //        }

        //        FaceTarget();
        //        break;
        //    case enemyState.Attacking:
        //        if (GameSettings.Instance.debug)  Debug.Log($"{gameObject.name} : ATTACKING " + target.name);
        //        if (fleeable && Vector3.Distance(target.transform.position, transform.position) < range) ;
        //        {
        //            state = enemyState.Chase;
        //        }
        //        FaceTarget();
        //        if (distance >= aggroLossRange)
        //        {
        //            state = enemyState.Chase;
        //        }
        //        enemyCombat.Combat();
        //        break;
        //    case enemyState.Dead:
        //        if(!died)
        //        {
        //            damageable.hpSlider.enabled = false;
        //            Die();
        //        }
        //        bodyLifetimer += Time.deltaTime;
        //        if(bodyLifetimer >= bodyLifetime)
        //        {
        //            Destroy(gameObject);
        //        }
        //        break;
        //    default:
        //        break;
        //}

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, aggroLossRange);
    }



}
