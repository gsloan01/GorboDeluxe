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
    float movementSpeed;

    Enemy thisEnemy;


    public void Initialize(EnemyMovementData data)
    {
        movementSpeed = data.movementSpeed;
        agent = GetComponent<NavMeshAgent>();
        GetComponent<Enemy>().onChangeState.AddListener(UpdateState);
        GetComponent<Enemy>().OnEnemyTargetChanged.AddListener(UpdateTarget);
    }
    private void Update()
    {
        switch (currentState)
        {
            case Enemy.enemyState.Idle:
                break;
            case Enemy.enemyState.Wander:
                break;
            case Enemy.enemyState.Flee:
                break;
            case Enemy.enemyState.Chase:
                if(target != null)
                {
                    FaceTarget();
                    agent.Move(target.transform.position);
                }
                else
                {
                    if (GameSettings.Instance.debug) Debug.Log("Trying to chase without a target!");
                }


                break;
            case Enemy.enemyState.Attacking:
                FaceTarget();
                break;
            case Enemy.enemyState.Dead:

                break;
            default:
                break;
        }
    }
    void FaceTarget()
    {
        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
        }
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
        Gizmos.DrawWireSphere(transform.position, agent.stoppingDistance);
        //Gizmos.DrawLine(transform.position, target.transform.position);
    }
}
