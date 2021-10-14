using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public EnemyData data;

    float bodyLifetime = 3.0f;


    public UnityEvent<GameObject> OnEnemyTargetChanged;

    float xpDropped = 5.0f;
    public float detectionRange = 8.0f;
    public float aggroLossRange = 15.0f;

    Health health;
    EnemyCombat enemyCombat;
    EnemyMovement enemyMovement;
    EnemyTargeting targetingSystem;


   
    public enemyState currentState = enemyState.Idle;

    public enum enemyState
    {
        Idle, Wander, Flee, Chase, Attacking, Dead
    }


    private void Awake()
    {
        health = GetComponent<Health>();
        //enemyCombat = GetComponent<EnemyCombat>();
        enemyMovement = GetComponent<EnemyMovement>();
        health.OnDeath.AddListener(OnDeath);

    }
    // Start is called before the first frame update
    void Start()
    {
        EnemyManager.Instance.OnEnemyCreate.Invoke(this);
        Debug.Log($"New Enemy Spawned : {data.name}");
    }

    void Update()
    {
        Debug.Log(currentState);
    }

    void OnDeath()
    {
        foreach(GameObject p in PlayerManager.Instance.players)
        {
            p.GetComponent<Player>().OnGainXP(xpDropped);
        }
        //PlayerManager.Instance.player.GetComponent<Player>().OnGainXP(xpDropped);
        Destroy(gameObject);
        
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, aggroLossRange);
    }



}
