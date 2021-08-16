using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public float detectionRange = 8.0f;
    public float aggroLossRange = 15.0f;

    GameObject target;
    NavMeshAgent agent;
    bool aggro;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.Instance.player;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.transform.position, transform.position);

        if(distance <= detectionRange || aggro)
        {
            if(!aggro) aggro = true;
            agent.SetDestination(target.transform.position);
            if(distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }

        if(distance >= aggroLossRange)
        {
            aggro = false;
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
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
