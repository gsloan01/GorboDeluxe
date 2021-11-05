using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    public EnemyData data;
    public EnemyDetection detection;

    public enemyState currentState = enemyState.Idle;

    protected NavMeshAgent agent;
    public Health HealthCPNT { get { return health; } }
    protected Health health;
    protected Vector3 spawnPosition;

    protected Player currentTarget;

    protected bool attacking, wandering = false;
    protected float deathTimer = 0;
    protected float wanderTimer;

    public enum enemyState
    {
        Idle, Flee, Chase, Attacking, Dead
    }

    //---------------------------------------------------------------

    private void Awake()
    {
        spawnPosition = transform.position;
        health = GetComponent<Health>();
        agent = GetComponent<NavMeshAgent>();
        health.OnDeath.AddListener(OnDeath);
        wanderTimer = data.wanderFrequency;
        

    }

    void Start()
    {
        EnemyManager.Instance.OnEnemyCreate.Invoke(this);
        Debug.Log($"New Enemy Spawned : {data.name}");
    }

    //call this method whenever a new player is added to the detection pool
    public abstract void OnFindNewPlayer(Player newPlayer);

    public abstract void Chase();


    public abstract void Combat();

    public abstract void Wander();

    void OnDeath()
    {
        foreach(GameObject p in PlayerManager.Instance.players)
        {
            p.GetComponent<Player>().OnGainXP(data.xpDropped);
        }
        Debug.Log("Destroying enemy instantly after death in Enemy.cs / OnDeath");
        currentState = enemyState.Dead;
        EnemyManager.Instance.OnEnemyDeath.Invoke(this);
        Destroy(gameObject);
        
    }

    protected void FaceTarget(GameObject target)
    {

        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data.detectionRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, data.aggroLossRange);
    }



}
