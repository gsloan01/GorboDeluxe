using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] float attackRange = -1;
    float attackTimer = .75f;
    float damageTimer = .35f;
    float attackOvertimer = .75f;
    [SerializeField] List<EnemyRangedAttack> attacks = new List<EnemyRangedAttack>();
    public Transform shootTransform;

    private void Start()
    {
        agent.stoppingDistance = (attackRange > 0) ? attackRange : agent.stoppingDistance;
        //if attack range was never set
        if(attackRange == -1)
        {
            //attack range is as much as they could detect and some
            attackRange = data.detectionRange + 0.5f;
        }
    }

    void Update()
    {
        //Debug.Log(currentState);
        switch (currentState)
        {
            case enemyState.Idle:
                //Wander
                break;
            case enemyState.Flee:
                //run away from the player
                break;
            case enemyState.Chase:
                Chase();
                break;
            case enemyState.Attacking:
                Combat();
                break;
            case enemyState.Dead:
                break;
            default:
                break;
        }
    }

    private void FixedUpdate()
    {
        //if(currentTarget != null)
        //{
        //    //if im chasing or attacking my target
        //    if(currentState == enemyState.Chase || currentState == enemyState.Attacking)
        //    {
        //        //shoot a raycast at it
        //        if(Physics.Raycast(transform.position, (currentTarget.transform.position - transform.position), out RaycastHit hitinfo))
        //        {
        //            //if i hit the player
        //            if(hitinfo.collider.gameObject.CompareTag("Player"))
        //            {
        //                //set stopping distance to shootdistance - .5f
        //            }
        //            else
        //            {

        //            }
        //        }
        //    }
        //}
    }

    /// <summary>
    /// Method called by detection to show that a new player was found
    /// </summary>
    /// <param name="newPlayer">Player that was found</param>
    public override void OnFindNewPlayer(Player newPlayer)
    {
        //check for threat levels if multiplayer
        currentTarget = newPlayer;
        currentState = enemyState.Chase;
    }

    public override void Chase()
    {
        FaceTarget(currentTarget.gameObject);
        if(Vector3.Distance(transform.position, currentTarget.centerMassTransform.position) <= attackRange)
        {
            currentState = enemyState.Attacking;
            agent.isStopped = true;
        }
        else
        {
            agent.SetDestination(currentTarget.centerMassTransform.position);

        }

    }

    public override void Combat()
    {
        if(!attacking)
        {
            FaceTarget(currentTarget.gameObject);
            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0)
            {
                //Begin the attack (Coroutine?)
                AttackStarted();
            }
            if (Vector3.Distance(transform.position, currentTarget.centerMassTransform.position) >= attackRange)
            {
                currentState = enemyState.Chase;
            }
        }
        else
        {
            damageTimer -= Time.deltaTime;
            if(damageTimer <= 0)
            {
                ShootProjectile();
                AttackOver();
            }

        }

    }

    void AttackStarted()
    {
        Debug.Log("Attack Started");
        attackTimer = .75f;
        damageTimer = .35f;
        attacking = true;
    }

    /// <summary>
    /// Method that will deal damage to the player
    /// </summary>
    /// <param name="delay">Amount of time until next damage time. If value is less than zero, there will only be the one damage proc.</param>
    void ShootProjectile(float delay = -1.0f)
    {
        Debug.Log("ProjectileShot");
        damageTimer = (delay == -1.0f && delay < 0) ? float.MaxValue : delay;
        EnemyRangedAttack newAttack = Instantiate<EnemyRangedAttack>(attacks[Random.Range(0, attacks.Count)], shootTransform.position, transform.rotation);
        newAttack.target = currentTarget.gameObject;
        newAttack.targetingTransform = currentTarget.centerMassTransform;
    }

    void AttackOver()
    {
        Debug.Log("Attack Ended");
        attacking = false;
    }

    public override void Wander()
    {
        throw new System.NotImplementedException();
    }

    
}
