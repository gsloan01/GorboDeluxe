using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    public EnemyData data;
    public EnemyDetection detection;
    protected EnemyAnimationController enemyAnimationController;
    public GameObject bodyDisappearEffect;

    [SerializeField] float deathTime = 2.0f;
    public enemyState currentState = enemyState.Idle;

    protected NavMeshAgent agent;
    public Health HealthCPNT { get { return health; } }
    protected Health health;
    protected Vector3 spawnPosition;

    protected Player currentTarget;

    protected bool attacking, wandering = false;
    
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
        enemyAnimationController = GetComponent<EnemyAnimationController>();
        health.OnDeath.AddListener(OnDeath);
        health.OnHurt.AddListener(enemyAnimationController.SetHurt);
        wanderTimer = data.wanderFrequency;
        

    }

    void Start()
    {
        EnemyManager.Instance.OnEnemyCreate.Invoke(this);
        
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
        
        currentState = enemyState.Dead;
        enemyAnimationController.SetDeath();
        StartCoroutine(Death());
        
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(deathTime);
        EnemyManager.Instance.OnEnemyDeath.Invoke(this);
        
        Destroy(Instantiate(bodyDisappearEffect, transform.position, transform.rotation), 1);
        
        Destroy(gameObject);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, data.detectionRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, data.aggroLossRange);
    }



}
