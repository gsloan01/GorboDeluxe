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
    float bodyLifetime = 30.0f;


    GameObject target;
    NavMeshAgent agent;
    Health health;
    EnemyCombat enemyCombat;
    Damageable damageable;

    //Determines if the enemy has finished dying
    bool died;
    bool ranged;
    float range;
    bool fleeable;

    public enum enemyState
    {
        Idle, Chase, Attacking, Dead
    }

    enemyState state;

    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.Instance.player;
        agent = GetComponent<NavMeshAgent>();
        EnemyManager.Instance.OnEnemySpawn(this);
        damageable = GetComponent<Damageable>();
        ranged = enemyCombat.data.stayAtRange;
        fleeable = enemyCombat.data.flee;
        if (ranged) range = enemyCombat.data.stayAwayRange;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCombat.target = target;
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
                if(ranged)
                {
                    float currentDistanceFromTarget = Vector3.Distance(target.transform.position, transform.position);
                    if (currentDistanceFromTarget > range)
                    {
                        agent.Move((target.transform.position - transform.position).normalized);
                    }
                    else if(fleeable && currentDistanceFromTarget < range)
                    {
                        //run away to a safe distance
                    }
                    else
                    {
                        state = enemyState.Attacking;
                    }
                       

                }
                else
                {
                    if (distance >= aggroLossRange)
                    {
                        state = enemyState.Idle;
                    }
                    agent.SetDestination(target.transform.position);
                }
                FaceTarget();
                break;
            case enemyState.Attacking:
                Debug.Log($"{gameObject.name} : ATTACKING");
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
        //Gizmos.DrawLine(transform.position, target.transform.position);
    }
}
