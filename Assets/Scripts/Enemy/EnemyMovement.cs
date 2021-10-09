using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject target;
    Enemy.enemyState currentState = Enemy.enemyState.Idle;

    Enemy thisEnemy;
    EnemyMovementData data;

    float detectionRange = 5.0f;
    float attackRange = 2.0f;
    bool active = true;

    public void ToggleActive()
    {
        active = !active;
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        thisEnemy = GetComponent<Enemy>();

        data = thisEnemy.data.movementData;

        thisEnemy.OnChangeState.AddListener(UpdateState);
        thisEnemy.OnEnemyTargetChanged.AddListener(UpdateTarget);
        agent.speed = data.movementSpeed;
        target = PlayerManager.Instance.player;
        GetComponent<Health>().OnDeath.AddListener(ToggleActive);
    }
    private void Update()
    {
        if(active)
        {
            //if there is a target found

            switch (currentState)
            {
                case Enemy.enemyState.Idle:

                    if(Vector3.Distance(target.transform.position, transform.position) < detectionRange)
                    {
                        thisEnemy.OnChangeState.Invoke(Enemy.enemyState.Chase);

                    }

                    break;
                case Enemy.enemyState.Chase:
                    FaceTarget();

                    agent.SetDestination(target.transform.position);
                    if (Vector3.Distance(target.transform.position, transform.position) <= attackRange)
                    {
                        thisEnemy.OnChangeState.Invoke(Enemy.enemyState.Attacking);
                        
                    }
                    Debug.Log($"Chasing {target.name}");
                    break;
                case Enemy.enemyState.Attacking:
                    FaceTarget();
                    if (Vector3.Distance(target.transform.position, transform.position) > agent.stoppingDistance)
                    {
                        thisEnemy.OnChangeState.Invoke(Enemy.enemyState.Chase);

                    }
                    break;
                case Enemy.enemyState.Dead:
                    ToggleActive();
                    break;
                default:
                    break;
            }
            


            
        }
    }
    void FaceTarget()
    {

        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

    }

    /// <summary>
    /// Checks the enemies current state, to avoid constant updating, only updating when necessary
    /// </summary>
    void UpdateState(Enemy.enemyState newState)
    {
        currentState = newState;
    }
    void UpdateTarget(GameObject newTarget)
    {
        target = newTarget;
    }


    private void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.blue;
        if (target != null)
        {
            Gizmos.DrawSphere(target.transform.position, 1);
        }
        //Gizmos.DrawWireSphere(transform.position, agent.stoppingDistance);
        //Gizmos.DrawLine(transform.position, target.transform.position);
    }
}
