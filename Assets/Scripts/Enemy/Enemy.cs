using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Damageable))]
public class Enemy : MonoBehaviour
{
    public EnemyData data;
    float detectionRange = 8.0f;
    float aggroLossRange = 15.0f;
    float bodyLifetime = 3.0f;


    GameObject target;
    NavMeshAgent agent;
    Health health;
    EnemyCombat enemyCombat;
    Damageable damageable;

    //Determines if the enemy has finished dying
    bool died;
    bool ranged;
    bool fleeable;

    float range;
    float bodyLifetimer = 0;

    public enum enemyState
    {
        Idle, Chase, Attacking, Dead
    }

    enemyState state;

    // Start is called before the first frame update
    void Start()
    {
        //ON SPAWN EVENT
        EnemyManager.Instance.OnEnemySpawn(this);

        //GETTING COMPONENTS
        agent = GetComponent<NavMeshAgent>();
        damageable = GetComponent<Damageable>();
        health = GetComponent<Health>();
        enemyCombat = GetComponent<EnemyCombat>();

        //DATA GRABBING
        target = PlayerManager.Instance.player;
        ranged = enemyCombat.data.stayAtRange;
        fleeable = enemyCombat.data.flee;
        detectionRange = data.detectionRange;
        aggroLossRange = data.aggroLossRange;
        if (ranged) range = enemyCombat.data.stayAwayRange;
        else { range = agent.stoppingDistance + .5f; }
        Debug.Log($"New Enemy Spawned : {gameObject.name}, Ranged? : {(ranged ? "Yes" : "No")}");
    }

    // Update is called once per frame
    void Update()
    {

        if (target) enemyCombat.target = target;
        else { enemyCombat.target = null; }
        float distance = 0;
        if(!died) distance = Vector3.Distance(target.transform.position, transform.position);

        if (state != enemyState.Dead && health.isDead) state = enemyState.Dead;
        if(!target && !damageable.isDead)
        {
            state = enemyState.Idle;
        }

        switch (state)
        {
            case enemyState.Idle:
                if(distance <= detectionRange)
                {
                    state = enemyState.Chase;
                }
                break;
            case enemyState.Chase:
                if(GameSettings.Instance.debug) Debug.Log($"{gameObject.name} : MOVING");
                if (distance > range)
                {
                    agent.SetDestination(target.transform.position);
                    //agent.Move((target.transform.position - transform.position) * Time.deltaTime);
                }
                else if(fleeable && distance < range)
                {
                    //run away to a safe distance
                    if (GameSettings.Instance.debug)  Debug.Log("Running from " + target.name);
                }
                if(distance <= range)
                {
                    state = enemyState.Attacking;
                }

                if( distance > detectionRange)
                {
                    state = enemyState.Idle;
                }

                FaceTarget();
                break;
            case enemyState.Attacking:
                if (GameSettings.Instance.debug)  Debug.Log($"{gameObject.name} : ATTACKING " + target.name);
                if (fleeable && Vector3.Distance(target.transform.position, transform.position) < range) ;
                {
                    state = enemyState.Chase;
                }
                FaceTarget();
                if (distance >= aggroLossRange)
                {
                    state = enemyState.Chase;
                }
                enemyCombat.Combat();
                break;
            case enemyState.Dead:
                if(!died)
                {
                    Die();
                }
                bodyLifetimer += Time.deltaTime;
                if(bodyLifetimer >= bodyLifetime)
                {
                    Destroy(gameObject);
                }
                break;
            default:
                break;
        }
        
    }

    void FaceTarget()
    {
        if(target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
        }
    }

    void Die()
    {
        EnemyManager.Instance.OnEnemyDeath(this);
        died = true;
        agent.isStopped = true;
        //Quit all code stuff and make ragdolling work.
        //drop some gold and items
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, aggroLossRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
        //Gizmos.DrawLine(transform.position, target.transform.position);
    }
}
